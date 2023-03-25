using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.RoomTypeEntity;

namespace Domain.ViewModel.RoomEntity;

// TODO : Room view model
public class RoomDetailEntity
{
    public int RoomId { get; set; }
    public int AvailableSlots { get; set; }
    public string RoomName { get; set; } = null!;
    public int FlatId { get; set; }
    public FlatBasicDetailEntity Flat { get; set; }
    public int RoomTypeId { get; set; }
    public RoomTypeDetailEntity RoomType { get; set; }
}