namespace Domain.QueryFilter;

public class ServiceTypeFilter : PagingFilter
{
    public string? Name { get; set; }

    public string? Status { get; set; }
}