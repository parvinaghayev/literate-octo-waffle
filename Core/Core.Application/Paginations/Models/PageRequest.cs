namespace Core.Application.Paginations.Models;

public class PageRequest
{
    public PageRequest()
    {
        Size = 10;
        Index = 1;
    }

    public PageRequest(int size, int index)
    {
        Size = size <= 0 ? 10 : size;
        Index = index <= 0 ? 1 : index;
    }

    public int Size { get; set; }
    public int Index { get; set; }
}