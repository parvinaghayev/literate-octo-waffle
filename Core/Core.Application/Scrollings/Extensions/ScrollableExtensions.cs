using Core.Application.Scrollings.Models;

namespace Core.Application.Scrollings.Extensions
{
    public static class ScrollableExtensions
    {
        public static ScrollResponse<T> ToScrollable<T>(this IQueryable<T> queryable, int index, int size)
        {
            ScrollResponse<T> scrollable = new();

            double pageCountDouble = (double)queryable.Count() / size;

            scrollable.Index = index;
            scrollable.Size = size;
            scrollable.Total = queryable.Count();
            scrollable.Max = pageCountDouble != (int)pageCountDouble ? (int)pageCountDouble + 1 : (int)pageCountDouble;
            scrollable.Min = scrollable.Max > 0 ? 1 : 0;
            scrollable.HasNext = scrollable.Max > index ? true : false;
            scrollable.Datas = queryable.Skip(size * (index - 1)).Take(size).ToList();

            return scrollable;
        }
    }
}