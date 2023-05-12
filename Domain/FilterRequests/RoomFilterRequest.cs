using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class RoomFilterRequest : PagingFilter
{
    public int? RoomId { get; set; }

    public string? RoomName { get; set; }

    public int? RoomTypeId { get; set; }

    public int? FlatId { get; set; }

    public int? AvailableSlots { get; set; }

    public decimal? ElectricityAttribute { get; set; }

    public decimal? WaterAttribute { get; set; }
}