using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Models;
using ANYU.Api.Requests;
using ANYU.Api.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ANYU.Api.Services;

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
            var courseInstance = await _context.CourseInstances
                .Include(x => x.Course)
                .Include(x => x.Semester)
                .OrderBy(x => x.Semester.StartDate)
                .AsQueryable()
                .AsNoTracking()
                .FirstOrDefaultAsync(instance => instance.Course.Code == request.Code, cancellationToken);
            if (courseInstance == null)
            {
                return Result<CourseResponse>.Failure("Course not found");
            }
            var courseResponse = new CourseResponse
            {
                CourseId = courseInstance.Course.CourseId,
                Name = courseInstance.Course.Name,
                Code = courseInstance.Course.Code,
                Category = courseInstance.Course.Category,
                Credit = courseInstance.Course.Credit,
                Description = courseInstance.Course.Description,
                InstanceDescription = courseInstance.Description,
                StartDate = courseInstance.Semester.StartDate,
                EndDate = courseInstance.Semester.EndDate
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
