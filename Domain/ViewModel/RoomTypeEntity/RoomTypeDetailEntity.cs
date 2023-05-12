namespace Domain.ViewModel.RoomTypeEntity;

public class RoomTypeDetailEntity
{
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; }
    public int TotalSlot { get; set; } // Max slot, Min slot = 1
    public string? Description { get; set; }
    public string Status { get; set; } // Active / Inactive
}