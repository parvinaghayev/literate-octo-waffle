namespace Core.Application.Scrollings.Models
{
    public class ScrollResponse<T>
    {
        public bool HasNext { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public int Total { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public List<T> Datas { get; set; }
    }
}