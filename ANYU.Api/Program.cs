using System.Reflection;
using System.Text.RegularExpressions;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
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

        // Add MediatR
        builder.Services.AddMediatR(typeof(Program));

        // Add DbContext
        builder.Services.AddSqlServer<AnyuDbContext>("ConnectionString");

        // Add Routing
        builder.Services.AddRouting(options => { options.LowercaseUrls = true; });

        // Add Controllers
        builder.Services.AddControllers(mvcOptions => mvcOptions.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer())));
        builder.Services.AddEndpointsApiExplorer();

        // Add Swagger
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

        // Add Authorization
        builder.Services.AddAuthorization();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
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
