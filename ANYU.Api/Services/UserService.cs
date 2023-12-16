using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Models;
using ANYU.Api.Requests;
using ANYU.Api.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ANYU.Api.Services;

// todo: move to separate files
// users
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

// courses
public class CourseService : IRequestHandler<GetCoursesRequest, PagedListResult<CourseResponse>>, IRequestHandler<GetCourseRequest, Result<CourseResponse>>
{
    private readonly AnyuDbContext _context;
    private readonly ILogger<CourseService> _logger;

    public CourseService(AnyuDbContext context, ILogger<CourseService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PagedListResult<CourseResponse>> Handle(GetCoursesRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var totalCountQuery = _context.Courses
                .AsQueryable()
                .AsNoTracking();
            totalCountQuery = ApplyFiltering(totalCountQuery, request.Filtering);
            var totalCount = await totalCountQuery.CountAsync(cancellationToken);
            var query = _context.Courses
                .AsQueryable()
                .AsNoTracking();
            query = ApplyFiltering(query, request.Filtering);
            query = query.ApplySorting(request.Sorting, "CreatedAt", x => x.CreatedAt);
            query = query.ApplyPaging(request.Pagination);
            var coursesResponse = query.Select(course => new CourseResponse
                {
                    CourseId = course.CourseId,
                    Name = course.Name,
                    Code = course.Code,
                    Category = course.Category,
                    Credit = course.Credit,
                    Description = course.Description
                })
                .ToList();
            return PagedListResult<CourseResponse>.Ok(coursesResponse, request.Pagination, totalCount);
        }
        catch (Exception e)
        {
            return PagedListResult<CourseResponse>.Failure(e.Message);
        }
    }

    public async Task<Result<CourseResponse>> Handle(GetCourseRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var course = await _context.Courses
                .AsQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(course => course.Code == request.Code, cancellationToken);
            if (course == null)
            {
                return Result<CourseResponse>.Failure("Course not found");
            }
            var courseResponse = new CourseResponse
            {
                CourseId = course.CourseId,
                Name = course.Name,
                Code = course.Code,
                Category = course.Category,
                Credit = course.Credit,
                Description = course.Description
            };
            return Result<CourseResponse>.Ok(courseResponse);
        }
        catch (Exception e)
        {
            return Result<CourseResponse>.Failure(e.Message);
        }
    }

    private static IQueryable<Course> ApplyFiltering(IQueryable<Course> query, string filtering)
    {
        if (filtering == null)
        {
            return query;
        }
        return query.Where(course => course.Name.ToLower().Contains(filtering.ToLower()) ||
                                     course.Code.ToLower().Contains(filtering.ToLower()) ||
                                     course.Category.ToLower().Contains(filtering.ToLower()));
    }
}
