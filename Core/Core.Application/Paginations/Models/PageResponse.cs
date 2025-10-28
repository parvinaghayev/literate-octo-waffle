namespace Core.Application.Paginations.Models;

public class PageResponse<T> where T : class
{
    public int Size { get; set; }
    public int Index { get; set; }
    public int Total { get; set; }
    public int PageCount { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrev { get; set; }
    public List<T> Data { get; set; }
}