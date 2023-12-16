using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Responses;
using ANYU.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANYU.Api.Controllers;

// todo: move to separate files
// users
[ApiController]
[Authorize(Policy = "AuthZPolicy")]
// [AllowAnonymous]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Get All Users
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<UserResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<UserResponse>))]
    public async Task<IActionResult> GetUsers([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetUsersRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}

// courses
[ApiController]
// [Authorize]
[AllowAnonymous]
[Route("[controller]")]
public class CoursesController : Controller
{
    private readonly IMediator _mediator;

    public CoursesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Get All Courses
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<CourseResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<CourseResponse>))]
    public async Task<IActionResult> GetCourses([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetCoursesRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}

// course instances
[ApiController]
// [Authorize]
[AllowAnonymous]
[Route("[controller]")]
public class CourseInstancesController : Controller
{
    private readonly IMediator _mediator;

    public CourseInstancesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Get All Course Instances
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<CourseInstanceResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<CourseInstanceResponse>))]
    public async Task<IActionResult> GetCourseInstances([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetCourseInstancesRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}

// lecture labs
[ApiController]
// [Authorize]
[AllowAnonymous]
[Route("[controller]")]
public class LectureLabsController : Controller
{
    private readonly IMediator _mediator;

    public LectureLabsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Get All Lecture Labs
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<LectureLabResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<LectureLabResponse>))]
    public async Task<IActionResult> GetLectureLabs([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetLectureLabsRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}

// semesters
[ApiController]
// [Authorize]
[AllowAnonymous]
[Route("[controller]")]
public class SemestersController : Controller
{
    private readonly IMediator _mediator;

    public SemestersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Get All Semesters
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<SemesterResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<SemesterResponse>))]
    public async Task<IActionResult> GetSemesters([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetSemestersRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}

// universities
[ApiController]
// [Authorize]
[AllowAnonymous]
[Route("[controller]")]
public class UniversitiesController : Controller
{
    private readonly IMediator _mediator;

    public UniversitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    ///     Get All Universities
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<UniversityResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<UniversityResponse>))]
    public async Task<IActionResult> GetUniversities([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetUniversitiesRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}
