using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class BuildingFilterRequest : PagingFilter
{
    public string? BuildingName { get; set; }

    public string? Description { get; set; }

    public int? TotalFloor { get; set; }

    public int? TotalRooms { get; set; }

    public bool? Status { get; set; }

    // Management Company
    public int? AccountId { get; set; }

    public int? AreaId { get; set; }
}