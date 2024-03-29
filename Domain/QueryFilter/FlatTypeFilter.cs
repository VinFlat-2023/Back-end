namespace Domain.QueryFilter;

public class FlatTypeFilter : PagingFilter
{
    public string? FlatTypeName { get; set; }
    public int? RoomCapacity { get; set; }
    public bool? Status { get; set; }

    public int BuildingId { get; set; }
}