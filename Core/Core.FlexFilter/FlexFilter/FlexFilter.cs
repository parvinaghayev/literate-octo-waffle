namespace Core.FlexFilter.FlexFilter;

public class FlexFilter
{
    public Sort? Sort { get; set; }
    public Filter Filter { get; set; }

    public FlexFilter(Sort sort, Filter filter)
    {
        Sort = sort;
        Filter = filter;
    }

    public FlexFilter()
    {
    }
}