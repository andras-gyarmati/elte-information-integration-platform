using System.Linq.Expressions;
using ANYU.Api.Abstraction;

namespace ANYU.Api.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> ApplySorting<TEntity, TResult>(this IQueryable<TEntity> query, Sorting sorting, string columnName, Expression<Func<TEntity, TResult>> prop)
    {
        if (sorting == null || sorting.SortBy != columnName)
        {
            return query;
        }
        return sorting.IsAscending ? query.OrderBy(prop) : query.OrderByDescending(prop);
    }

    public static IQueryable<TEntity> ApplyDefaultSorting<TEntity, TResult>(this IQueryable<TEntity> query, Sorting sorting, Expression<Func<TEntity, TResult>> prop)
    {
        if (sorting is { SortBy: not null })
        {
            return query;
        }
        return query.OrderBy(prop);
    }

    public static IQueryable<TEntity> ApplyPaging<TEntity>(this IQueryable<TEntity> query, Pagination pagination)
    {
        if (pagination == null)
        {
            return query;
        }
        var startIndex = (pagination.Page - 1) * pagination.PageResults;
        return query.Skip(startIndex).Take(pagination.PageResults);
    }
}
