using Domain.ViewModel.AreaEntity;

namespace Domain.ViewModel.BuildingEntity;

public class BuildingDetailEntity
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; } = null!;
    public string? Description { get; set; }
    public int? TotalRooms { get; set; }
    public bool Status { get; set; }
    public string BuildingAddress { get; set; }
    public decimal AveragePrice { get; set; }
    public string? BuildingImageUrl1 { get; set; }
    public string? BuildingImageUrl2 { get; set; }
    public string? BuildingImageUrl3 { get; set; }
    public string? BuildingImageUrl4 { get; set; }
    public string? BuildingImageUrl5 { get; set; }
    public string? BuildingImageUrl6 { get; set; }
    public int EmployeeId { get; set; }
    public EmployeeBuildingDetailEntity Employee { get; set; }
    public int AreaId { get; set; }
    public AreaDetailEntity Area { get; set; }
}