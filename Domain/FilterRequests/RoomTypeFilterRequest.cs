using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class RoomTypeFilterRequest : PagingFilter
{
    public int? RoomTypeId { get; set; }
    public string? RoomTypeName { get; set; }
    public int? TotalSlot { get; set; } // Max slot, Min slot = 1
    public string? Status { get; set; } // Active / Inactive
}