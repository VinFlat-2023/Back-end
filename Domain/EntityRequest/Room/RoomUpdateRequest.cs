namespace Domain.EntityRequest.Room;

public class RoomUpdateRequest
{
    public string RoomSignName { get; set; }
    public int TotalSlot { get; set; } // Max slot, Min slot = 1
    public string Status { get; set; } // Active / Inactive
}