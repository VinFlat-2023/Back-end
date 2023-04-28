namespace Domain.QueryFilter;

public class RoomFilter : PagingFilter
{
    public int? RoomId { get; set; }
    public string? RoomSignName { get; set; }
    public int? TotalSlot { get; set; } // Max slot, Min slot = 1
    public string? Description { get; set; }
    public string? Status { get; set; } // Active / Inactive
}