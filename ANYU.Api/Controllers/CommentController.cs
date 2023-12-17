using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Requests;
using ANYU.Api.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANYU.Api.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class CommentController : Controller
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(PagedListResult<CommentResponse>))]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedListResult<CommentResponse>))]
    public async Task<IActionResult> GetComments([FromQuery] int? page, [FromQuery] int? pageResults)
    {
        var filtering = HttpContext.Request.Headers["Filtering"].FirstOrDefault();
        var pagination = new Pagination();
        pagination.Page = page ?? pagination.Page;
        pagination.PageResults = pageResults ?? pagination.PageResults;
        var sorting = new Sorting { SortBy = "CreatedOn", IsAscending = false };
        var request = new GetCommentRequest { Filtering = filtering, Sorting = sorting, Pagination = pagination };
        var result = await _mediator.Send(request);
        return result.ToHttpResponse();
    }
}