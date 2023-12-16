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
        // for debug if course or courseinstance or semester tables have no data add some dummy data
        if (!_context.Courses.Any())
        {
            var course = new Course
            {
                Name = "Course 1",
                Code = "C1",
                Category = "Category 1",
                Credit = 1,
                Description = "Description 1",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            _context.Courses.Add(course);
            await _context.SaveChangesAsync(cancellationToken);
        }
        if (!_context.Semesters.Any())
        {
            var semester = new Semester
            {
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow,
                StudyPeriodWeeks = 14,
                ExamPeriodWeeks = 6,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync(cancellationToken);
        }
        if (!_context.CourseInstances.Any())
        {
            var courseInstance = new CourseInstance
            {
                CourseId = 1,
                SemesterId = 1,
                Description = "Description 1",
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "System"
            };
            _context.CourseInstances.Add(courseInstance);
            await _context.SaveChangesAsync(cancellationToken);
        }
        // end debug, remove if not needed

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
                EndDate = courseInstance.Semester.EndDate,
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
