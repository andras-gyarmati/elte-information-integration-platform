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