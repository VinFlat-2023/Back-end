using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.RoomTypeEntity;

namespace Domain.ViewModel.RoomEntity;

public class RoomDetailEntity
{
    public int RoomId { get; set; }

    public string RoomName { get; set; }

    public int RoomTypeId { get; set; }

    public virtual RoomTypeDetailEntity RoomType { get; set; }

    public int AvailableSlots { get; set; }

    public int FlatId { get; set; }

    public virtual FlatDetailEntity Flat { get; set; }

    public decimal ElectricityAttribute { get; set; }

    public decimal WaterAttribute { get; set; }
}