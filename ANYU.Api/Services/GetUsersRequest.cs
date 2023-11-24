using ANYU.Api.Abstraction;
using ANYU.Api.Responses;
using MediatR;

namespace ANYU.Api.Services;

public class GetUsersRequest : IRequest<PagedListResult<UserResponse>>
{
    public string Filtering { get; set; }

    public Sorting Sorting { get; set; }

    public Pagination Pagination { get; set; }
}
