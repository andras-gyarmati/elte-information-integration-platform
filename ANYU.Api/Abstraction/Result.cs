using System.Text.Json.Serialization;
using ANYU.Api.Models.Enums;

namespace ANYU.Api.Abstraction;

public class Result<T>
{
    public Result(T value, string errorMessage, ErrorType errorType)
    {
        ErrorMessage = errorMessage;
        ErrorType = errorType;
        Value = value;
    }

    public T Value { get; }

    public string ErrorMessage { get; set; }

    [JsonIgnore]
    public ErrorType ErrorType { get; set; }

    [JsonIgnore]
    public bool HasValue => Value != null;

    [JsonIgnore]
    public bool IsSuccess => ErrorType == ErrorType.NoError;

    public static Result<T> Ok(T value)
    {
        return new Result<T>(value, null, ErrorType.NoError);
    }

    public static Result<T> Failure(string message)
    {
        return new Result<T>(default, message, ErrorType.System);
    }

    public static Result<T> AccessDenied(string message)
    {
        return new Result<T>(default, message, ErrorType.AccessDenied);
    }

    public static Result<T> NotFound(string message)
    {
        return new Result<T>(default, message, ErrorType.NotFound);
    }

    public static Result<T> BadRequest(string message)
    {
        return new Result<T>(default, message, ErrorType.BadRequest);
    }
}
