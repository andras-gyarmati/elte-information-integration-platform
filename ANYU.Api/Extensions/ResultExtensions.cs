using ANYU.Api.Abstraction;
using ANYU.Api.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace ANYU.Api.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToHttpResponse<T>(this Result<T> result)
    {
        if (result.IsSuccess && !result.HasValue)
        {
            return new NoContentResult();
        }
        if (result.IsSuccess && result.HasValue)
        {
            return new OkObjectResult(result);
        }
        if (result.ErrorType == ErrorType.NotFound)
        {
            return new NotFoundObjectResult(result);
        }
        if (result.ErrorType == ErrorType.AccessDenied)
        {
            return new UnauthorizedObjectResult(result);
        }
        return new BadRequestObjectResult(result);
    }
}
