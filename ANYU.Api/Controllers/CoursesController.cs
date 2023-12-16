using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Requests;
using ANYU.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANYU.Api.Controllers;

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

    /// <summary>
    ///     Get Course By code
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    [HttpGet("{code}")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Result<CourseResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Result<CourseResponse>))]
    public async Task<IActionResult> GetCourseById([FromRoute] string code)
    {
        var request = new GetCourseRequest { Code = code };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}