namespace Domain.EntityRequest.Flat;

public class FlatCreateRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; } = null!;
    public int? WaterMeter { get; set; }
    public int? ElectricityMeter { get; set; }
    public int FlatTypeId { get; set; }
    public int BuildingId { get; set; }
}