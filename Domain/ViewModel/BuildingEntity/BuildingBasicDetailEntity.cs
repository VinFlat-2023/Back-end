namespace Domain.ViewModel.BuildingEntity;

public class BuildingBasicDetailEntity
{
    public int BuildingId { get; set; }
    public string BuildingName { get; set; }
    public string BuildingPhoneNumber { get; set; }
    public string BuildingAddress { get; set; }
    public string AveragePrice { get; set; }
    public string AreaName { get; set; }
    public string AvailableFlat { get; set; }
    public string? ImageUrl { get; set; }
}