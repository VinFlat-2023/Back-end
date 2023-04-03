namespace Domain.EntityRequest.Building;

public class BuildingCreateRequest
{
    public string? BuildingName { get; set; }
    public string? BuildingAddress { get; set; }
    public string? Description { get; set; }
    public decimal? CoordinateX { get; set; }
    public decimal? CoordinateY { get; set; }
    public string? BuildingPhoneNumber { get; set; }
    public decimal? AveragePrice { get; set; }
    public bool? Status { get; set; }
    public int AreaId { get; set; }
}