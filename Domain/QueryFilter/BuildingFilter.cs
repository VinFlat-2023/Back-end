namespace Domain.QueryFilter;

public class BuildingFilter : PagingFilter
{
    public string? BuildingName { get; set; }

    public string? Description { get; set; }
    public int? TotalFloor { get; set; }

    // TODO : Add more properties about price per water / electricity / gas / etc
    // TODO : Total rooms = Total rooms created in building
    public int? TotalRooms { get; set; }
    public bool? Status { get; set; }

    public int? AccountId { get; set; }
    public int? AreaId { get; set; }
}