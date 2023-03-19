using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.FlatTypeEntity;

namespace Domain.ViewModel.FlatEntity;

public class FlatDetailEntity
{
    public int FlatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int MaxRoom { get; set; }
    public int AvailableRoom { get; set; }
    public int FlatTypeId { get; set; }
    public FlatTypeDetailEntity FlatType { get; set; }
    public int BuildingId { get; set; }
    public BuildingBasicDetailEntity Building { get; set; }
}