namespace Domain.QueryFilter;

public class FlatTypeFilter : PagingFilter
{
    public int? Capacity { get; set; }

    public string? Status { get; set; }
}