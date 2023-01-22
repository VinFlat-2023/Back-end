namespace Domain.QueryFilter;

public class RequestTypeFilter : PagingFilter
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }
}