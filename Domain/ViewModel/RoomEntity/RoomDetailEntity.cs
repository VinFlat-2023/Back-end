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

    public string Status { get; set; }

    public string? RoomImageUrl1 { get; set; }
    public string? RoomImageUrl2 { get; set; }
    public string? RoomImageUrl3 { get; set; }
    public string? RoomImageUrl4 { get; set; }
    public string? RoomImageUrl5 { get; set; }
    public string? RoomImageUrl6 { get; set; }

    public bool IsAnyOneRented { get; set; } = false;

    public virtual FlatBasicDetailEntity Flat { get; set; }

    public decimal ElectricityAttribute { get; set; }

    public decimal WaterAttribute { get; set; }
}