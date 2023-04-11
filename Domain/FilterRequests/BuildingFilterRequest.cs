using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class BuildingFilterRequest : PagingFilter
{
    public string? BuildingName { get; set; }
    public string? Description { get; set; }
    public int? TotalFlats { get; set; }
    public bool? Status { get; set; }
    public string? BuildingPhoneNumber { get; set; }
    public string? BuildingAddress { get; set; }
    public string? AreaName { get; set; }
    public string? EmployeeName { get; set; }
    public bool? SpareSlots { get; set; }
    public decimal? AveragePrice { get; set; }
}