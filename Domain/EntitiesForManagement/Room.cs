namespace Domain.EntitiesForManagement;

public class Room
{
    public Room()
    {
        UtilitiesRoom = new HashSet<UtilitiesRoom>();
    }

    public int RoomId { get; set; }
    public string RoomName { get; set; }
    public int RoomTypeId { get; set; }
    public virtual RoomType RoomType { get; set; }

    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; }

    // Available slot = TotalSlot - FilledSlot (Count dựa trên RoomId theo contract)
    public int AvailableSlots { get; set; }

    // Max slot, Min slot = 1
    // Apply to this room only (not apply to all rooms in this flat)
    public string? RoomImageUrl1 { get; set; }
    public string? RoomImageUrl2 { get; set; }
    public string? RoomImageUrl3 { get; set; }
    public string? RoomImageUrl4 { get; set; }
    public string? RoomImageUrl5 { get; set; }
    public string? RoomImageUrl6 { get; set; }
    public decimal ElectricityAttribute { get; set; }
    public decimal WaterAttribute { get; set; }
    public int BuildingId { get; set; }
    public virtual ICollection<UtilitiesRoom> UtilitiesRoom { get; set; }
}