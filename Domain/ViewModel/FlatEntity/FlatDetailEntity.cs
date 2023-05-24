using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.FlatTypeEntity;
using Domain.ViewModel.RoomEntity;

namespace Domain.ViewModel.FlatEntity;

public class FlatDetailEntity
{
    public int FlatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int MaxRoom { get; set; }
    public int AvailableRoom { get; set; }
    public string? FlatImageUrl1 { get; set; }
    public string? FlatImageUrl2 { get; set; }
    public string? FlatImageUrl3 { get; set; }
    public string? FlatImageUrl4 { get; set; }
    public string? FlatImageUrl5 { get; set; }
    public string? FlatImageUrl6 { get; set; }
    public int FlatTypeId { get; set; }
    public FlatTypeDetailEntity FlatType { get; set; }
    public int BuildingId { get; set; }
    public BuildingBasicDetailEntity Building { get; set; }
    public ICollection<RoomBasicDetailEntity> Rooms { get; set; }
}