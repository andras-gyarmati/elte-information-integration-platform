using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Models;
using ANYU.Api.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ANYU.Api.Services;

public class UserService : IRequestHandler<GetUsersRequest, PagedListResult<UserResponse>>
{
    private readonly AnyuDbContext _context;
    private readonly ILogger<UserService> _logger;

    public UserService(AnyuDbContext context, ILogger<UserService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PagedListResult<UserResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var totalCountQuery = _context.Users
                .AsQueryable()
                .AsNoTracking();
            totalCountQuery = ApplyFiltering(totalCountQuery, request.Filtering);
            var totalCount = await totalCountQuery.CountAsync(cancellationToken);
            var query = _context.Users
                .AsQueryable()
                .AsNoTracking();
            query = ApplyFiltering(query, request.Filtering);
            query = query.ApplySorting(request.Sorting, "CreatedAt", x => x.CreatedAt);
            query = query.ApplyPaging(request.Pagination);
            var usersResponse = query.Select(user => new UserResponse
                {
                    Name = user.Name,
                    Email = user.Email
                })
                .ToList();
            return PagedListResult<UserResponse>.Ok(usersResponse, request.Pagination, totalCount);
        }
        catch (Exception e)
        {
            return PagedListResult<UserResponse>.Failure(e.Message);
        }
    }

    private static IQueryable<User> ApplyFiltering(IQueryable<User> query, string filtering)
    {
        if (filtering == null)
        {
            return query;
        }
        return query.Where(user => user.Email.ToLower().Contains(filtering.ToLower()) ||
                                   user.Name.ToLower().Contains(filtering.ToLower()));
    }
}
