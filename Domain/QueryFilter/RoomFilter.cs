namespace Domain.QueryFilter;

public class RoomFilter : PagingFilter
{
    public string? RoomName { get; set; }

    public int? RoomTypeId { get; set; }

    public string? RoomTypeName { get; set; }

    public int? FlatId { get; set; }

    public string? FlatName { get; set; }

    public int? AvailableSlots { get; set; }

    public int? TotalSlot { get; set; }

    public decimal? ElectricityAttribute { get; set; }

    public decimal? WaterAttribute { get; set; }
}