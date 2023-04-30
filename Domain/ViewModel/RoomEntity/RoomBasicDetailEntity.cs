namespace Domain.ViewModel.RoomEntity;

// TODO : Room view model
public class RoomBasicDetailEntity
{
    public int RoomId { get; set; }
    public string RoomSignName { get; set; }
    public int TotalSlot { get; set; } // Max slot, Min slot = 1
    public string Description { get; set; }
    public string Status { get; set; } // Active / Inactive
    public int BuildingId { get; set; }
}