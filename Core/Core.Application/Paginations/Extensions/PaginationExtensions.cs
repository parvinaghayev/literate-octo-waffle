using Core.Application.Paginations.Models;

namespace Core.Application.Paginations.Extensions;

public static class PaginationExtensions
{
    public static PageResponse<T> ToPageable<T>(this IQueryable<T> queryable, int index, int size) where T : class
    {
        PageResponse<T> pageResponse = new();

        var count = queryable.Count();
        int pageCount = (int)Math.Ceiling(count / (double)size);

        pageResponse.Index = index;
        pageResponse.Size = size;
        pageResponse.Total = count;
        pageResponse.PageCount = pageCount;
        pageResponse.HasNext = index < pageCount;
        pageResponse.HasPrev = index > 1;
        pageResponse.Data = queryable.Skip(size * (index - 1)).Take(size).ToList();

        return pageResponse;
    }
}