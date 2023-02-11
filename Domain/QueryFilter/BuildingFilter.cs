namespace Domain.QueryFilter;

public class BuildingFilter : PagingFilter
{
    public string? BuildingName { get; set; }

    public string? Description { get; set; }
    public int? TotalRooms { get; set; }
    public bool? Status { get; set; }

    public int? AccountId { get; set; }
    public int? AreaId { get; set; }

    public string? AreaName { get; set; }
    public string? Username { get; set; }
}