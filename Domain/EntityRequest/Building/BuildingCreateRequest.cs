namespace Domain.EntityRequest.Building;

public class BuildingCreateRequest
{
    public string BuildingName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double? CoordinateX { get; set; }
    public string? ImageUrl { get; set; }
    public double? CoordinateY { get; set; }
    public bool Status { get; set; }
    public int AreaId { get; set; }
}