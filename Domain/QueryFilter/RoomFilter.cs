namespace Domain.QueryFilter;

public class RoomFilter : PagingFilter
{
    public int? AvailableSlots { get; set; }
    public string? RoomName { get; set; }
    public string? FlatName { get; set; }
    public string? RoomTypeName { get; set; }
}