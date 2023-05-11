namespace Domain.EntityRequest.RoomType;

public class RoomTypeUpdateRequest
{
    public string RoomTypeName { get; set; }
    public int TotalSlot { get; set; } // Max slot, Min slot = 1
    public string Status { get; set; } // Active / Inactive
}