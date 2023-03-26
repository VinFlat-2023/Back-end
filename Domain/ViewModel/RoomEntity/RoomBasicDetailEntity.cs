namespace Domain.ViewModel.RoomEntity;

// TODO : Room view model
public class RoomBasicDetailEntity
{
    public int RoomId { get; set; }
    public int AvailableSlots { get; set; }
    public string RoomName { get; set; } = null!;
}