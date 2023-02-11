using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class ServiceFilterRequest : PagingFilter
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }

    public double? Amount { get; set; }

    public int? ServiceTypeId { get; set; }
}