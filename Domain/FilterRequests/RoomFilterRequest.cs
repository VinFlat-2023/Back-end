namespace Domain.FilterRequests;

public class RoomFilterRequest
{
    public int? AvailableSlots { get; set; }
    public string? RoomName { get; set; }
    public string? FlatName { get; set; }
    public string? RoomTypeName { get; set; }
}