namespace Domain.EntitiesForManagement;

public class Room
{
    public Room()
    {
        Flats = new HashSet<Flat>();
    }

    public int RoomId { get; set; }
    public int AvailableSlots { get; set; }
    public virtual ICollection<Flat> Flats { get; set; }
}