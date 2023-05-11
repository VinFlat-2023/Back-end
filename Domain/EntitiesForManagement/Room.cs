namespace Domain.EntitiesForManagement;

public class Room
{
    public Room()
    {
        UtilitiesRoomFlats = new HashSet<UtilitiesRoom>();
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
    public string? RoomFlatImageUrl1 { get; set; }
    public string? RoomFlatImageUrl2 { get; set; }
    public string? RoomFlatImageUrl3 { get; set; }
    public string? RoomFlatImageUrl4 { get; set; }
    public string? RoomFlatImageUrl5 { get; set; }
    public string? RoomFlatImageUrl6 { get; set; }
    public decimal ElectricityAttribute { get; set; }
    public decimal WaterAttribute { get; set; }
    public virtual ICollection<UtilitiesRoom> UtilitiesRoomFlats { get; set; }
}