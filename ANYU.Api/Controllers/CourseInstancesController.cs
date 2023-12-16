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