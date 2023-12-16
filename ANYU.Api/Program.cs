using System.Reflection;
using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace ANYU.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add User Secrets configuration
        var userSecretsIdAttribute = typeof(Program).Assembly.GetCustomAttribute<UserSecretsIdAttribute>();
        if (userSecretsIdAttribute?.UserSecretsId != null)
        {
            builder.Configuration.AddUserSecrets(userSecretsIdAttribute.UserSecretsId);
        }

        // Add Environment Variables to the configuration
        builder.Configuration.AddEnvironmentVariables();

        // Add Auth
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(options =>
            {
                builder.Configuration.Bind("AzureAd", options);
                options.TokenValidationParameters.NameClaimType = "name";
            }, options => { builder.Configuration.Bind("AzureAd", options); });

        builder.Services.AddAuthorization(config =>
        {
            config.AddPolicy("AuthZPolicy", policyBuilder =>
                policyBuilder.Requirements.Add(new ScopeAuthorizationRequirement() { RequiredScopesConfigurationKey = $"AzureAd:Scopes" }));
        });
        
        // Add MediatR
        builder.Services.AddMediatR(typeof(Program));

        // Add DbContext
        var connectionString = builder.Configuration.GetConnectionString("AnyuDb");
        builder.Services.AddDbContext<AnyuDbContext>(options =>
            options.UseSqlServer(connectionString, sqlServerOptions =>
                sqlServerOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, // Maximum number of retries
                    maxRetryDelay: TimeSpan.FromSeconds(10), // Maximum delay between retries
                    errorNumbersToAdd: null))); // SQL error numbers to consider as transient


        // Add Routing
        builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

        // Add Controllers
        builder.Services.AddControllers(mvcOptions => mvcOptions.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())));
        builder.Services.AddEndpointsApiExplorer();

        // Add Swagger
        /*
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });
        */
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows()
                {
                    Implicit = new OpenApiOAuthFlow()
                    {
                        AuthorizationUrl = new Uri("https://login.microsoftonline.com/0133bb48-f790-4560-a64d-ac46a472fbbc/oauth2/v2.0/authorize"),
                        TokenUrl = new Uri("https://login.microsoftonline.com/0133bb48-f790-4560-a64d-ac46a472fbbc/oauth2/v2.0/token"),
                        Scopes = new Dictionary<string, string>
                        {
                            {
                                "api://cd6489d0-8e19-4b37-b8a4-5d3efe281fe0/ANYU-Api.Access",
                                "Access ANYU-Api"
                            }
                        }
                    }
                }
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "oauth2"
                        },
                        Scheme = "oauth2",
                        Name = "oauth2",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
            });
        });

        // Add CORS
        const string anyuCorsPolicy = "anyu-cors-policy";
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(anyuCorsPolicy,
                corsPolicyBuilder =>
                {
                    corsPolicyBuilder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Content-Disposition");
                });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        // if (app.Environment.IsDevelopment())
        // {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.OAuthAppName("Swagger Client");
                options.OAuthClientId("cd6489d0-8e19-4b37-b8a4-5d3efe281fe0");
                options.OAuthClientSecret("pmK8Q~w637oZlluEwMkC5YKWvlQ_ONhysDbw-by~");
                options.OAuthUseBasicAuthenticationWithAccessCodeGrant();
            });
        // }
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AnyuDbContext>();
#if !DEBUG
            MigrateDatabase(dbContext);
#endif
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();
        app.UseCors(anyuCorsPolicy);
        app.UseAuthorization();
        app.MapControllers();

        // Add Default Routes
        app.MapGet("/", async (context) => await context.Response.WriteAsync("Anyu API"));
        app.MapGet("/robots.txt", async (context) => await context.Response.WriteAsync("User-agent: * \nDisallow: /"));
        app.MapGet("/health", async (context) => await context.Response.WriteAsJsonAsync(new { Status = "Healthy" }));
#if DEBUG
        app.UseDeveloperExceptionPage();
#endif
        app.Run();
    }

    private static void MigrateDatabase(AnyuDbContext dbContext)
    {
        try
        {
            dbContext.Database.Migrate();
        }
        catch (Exception)
        {
            // todo: log
        }
    }

    private class SlugifyParameterTransformer : IOutboundParameterTransformer
    {
        public string TransformOutbound(object value)
        {
            return value == null ? null : Regex.Replace(value.ToString() ?? string.Empty, "([a-z])([A-Z])", "$1-$2").ToLower();
        }
    }
}
