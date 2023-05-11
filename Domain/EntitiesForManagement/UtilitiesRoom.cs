namespace Domain.EntitiesForManagement;

public class UtilitiesRoom
{
    public int UtilitiesRoomId { get; set; }

    //public int FlatId { get; set; }
    //public virtual Flat Flat { get; set; }
    public int RoomId { get; set; }
    public virtual Room Room { get; set; }
    public int UtilityId { get; set; }
    public virtual Utility Utility { get; set; }
}