namespace Domain.EntitiesForManagement;

public class Room
{
    public int RoomId { get; set; }
    public int AvailableSlots { get; set; }
    public string RoomName { get; set; } = null!;
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; }
    public int RoomTypeId { get; set; }
    public virtual RoomType RoomType { get; set; }
}