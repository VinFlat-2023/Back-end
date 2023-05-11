using Domain.ViewModel.FlatEntity;

namespace Domain.ViewModel.RoomEntity;

// TODO : Room view model
public class RoomTypeDetailEntity
{
    public int RoomTypeId { get; set; }
    public int AvailableSlots { get; set; }
    public string RoomName { get; set; } = null!;
    public int FlatId { get; set; }
    public FlatBasicDetailEntity Flat { get; set; }
    public RoomTypeEntity.RoomTypeDetailEntity RoomType { get; set; }
}