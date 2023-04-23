namespace Domain.EntitiesForManagement;

public class UtilitiesRoomFlat
{
    public int UtilitiesRoomFlatId { get; set; }

    //public int FlatId { get; set; }
    //public virtual Flat Flat { get; set; }
    public int RoomFlatId { get; set; }
    public virtual RoomFlat RoomFlat { get; set; }
    public int UtilityId { get; set; }
    public virtual Utility Utility { get; set; }
}