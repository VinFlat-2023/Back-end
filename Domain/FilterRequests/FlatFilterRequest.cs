using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class FlatFilterRequest : PagingFilter
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int? FlatTypeId { get; set; }
    public string? FlatTypeName { get; set; }
    public string? BuildingName { get; set; }
}