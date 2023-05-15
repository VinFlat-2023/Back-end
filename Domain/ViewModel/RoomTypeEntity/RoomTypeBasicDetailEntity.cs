namespace Domain.ViewModel.RoomTypeEntity;

// TODO : Room view model
public class RoomTypeBasicDetailEntity
{
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; }
    public int TotalSlot { get; set; } // Max slot, Min slot = 1
    public string Description { get; set; }
    public string Status { get; set; } // Active / Inactive
}