using ANYU.Api.Abstraction;
using ANYU.Api.Extensions;
using ANYU.Api.Responses;
using ANYU.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANYU.Api.Controllers;

[ApiController]
[Authorize]
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
