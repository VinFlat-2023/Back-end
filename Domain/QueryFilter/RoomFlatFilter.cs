namespace Domain.QueryFilter;

public class RoomFlatFilter
{
    public string? RoomName { get; set; }
    public int? RoomId { get; set; }
    public string? RoomSignName { get; set; }
    public int? FlatId { get; set; }
    public string? FlatName { get; set; }
    public int? AvailableSlots { get; set; }
    public int? TotalSlot { get; set; }
    public decimal? ElectricityAttribute { get; set; }
    public decimal? WaterAttribute { get; set; }
}