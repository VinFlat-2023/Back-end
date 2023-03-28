namespace Domain.EntitiesForManagement;

public class RoomType
{
    public int RoomTypeId { get; set; }
    public string RoomTypeName { get; set; }
    public string Description { get; set; }
    public int NumberOfSlots { get; set; }
    public int BuildingId { get; set; }
}