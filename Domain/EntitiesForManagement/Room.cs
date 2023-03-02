namespace Domain.EntitiesForManagement;

public class Room
{
    public int RoomId { get; set; }
    public int AvailableSlots { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; }
}