namespace Domain.EntitiesForManagement;

public class RoomType
{
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int NumberOfSlots { get; set; }
}