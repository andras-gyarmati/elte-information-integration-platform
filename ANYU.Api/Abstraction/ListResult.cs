using ANYU.Api.Models.Enums;

namespace ANYU.Api.Abstraction;

public class ListResult<T> : Result<ICollection<T>>
{
    public int TotalResults => Value?.Count ?? 0;

    public ListResult(
        ICollection<T> value,
        string errorMessage,
        ErrorType errorType) : base(value, errorMessage, errorType)
    {
    }

    public new static ListResult<T> Ok(ICollection<T> items)
    {
        return new ListResult<T>(items, null, ErrorType.NoError);
    }

    public new static ListResult<T> Failure(string errorMessage)
    {
        return new ListResult<T>(null, errorMessage, ErrorType.System);
    }

    public new static ListResult<T> AccessDenied(string message)
    {
        return new ListResult<T>(default, message, ErrorType.AccessDenied);
    }

    public new static ListResult<T> NotFound(string errorMessage)
    {
        return new ListResult<T>(null, errorMessage, ErrorType.NotFound);
    }

    public new static ListResult<T> BadRequest(string message)
    {
        return new ListResult<T>(default, message, ErrorType.BadRequest);
    }
}
