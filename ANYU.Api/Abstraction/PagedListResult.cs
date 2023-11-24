using ANYU.Api.Models.Enums;

namespace ANYU.Api.Abstraction;

public class PagedListResult<T> : Result<ICollection<T>>
{
    public int? CurrentPage { get; set; }

    public int? CurrentPageResults { get; set; }

    public int? TotalPages { get; set; }

    public int? TotalResults { get; set; }

    public PagedListResult(ICollection<T> value, string errorMessage, ErrorType errorType, int? currentPage = null,
        int? currentPageResults = null, int? totalPages = null, int? totalResults = null) : base(value, errorMessage, errorType)
    {
        CurrentPage = currentPage ?? 1;
        CurrentPageResults = currentPageResults ?? 10;
        TotalPages = totalPages;
        TotalResults = totalResults;
    }

    public static PagedListResult<T> Ok(ICollection<T> values, Pagination pagination, int totalCount)
    {
        return new PagedListResult<T>(value: values,
            errorMessage: null,
            errorType: ErrorType.NoError,
            currentPage: pagination?.Page ?? 1,
            currentPageResults: values.Count,
            totalPages: pagination == null ? 1 : (totalCount + pagination.PageResults - 1) / pagination.PageResults,
            totalResults: totalCount);
    }

    public new static PagedListResult<T> Failure(string message)
    {
        return new PagedListResult<T>(default, message, ErrorType.System);
    }

    public new static PagedListResult<T> AccessDenied(string message)
    {
        return new PagedListResult<T>(default, message, ErrorType.AccessDenied);
    }

    public new static PagedListResult<T> NotFound(string message)
    {
        return new PagedListResult<T>(default, message, ErrorType.NotFound);
    }

    public new static PagedListResult<T> BadRequest(string message)
    {
        return new PagedListResult<T>(default, message, ErrorType.BadRequest);
    }
}
