namespace Domain.EntityRequest.Flat;

public class FlatUpdateRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; } = null!;
    public int? WaterMeterBefore { get; set; }
    public int? ElectricityMeterBefore { get; set; }
    public int? WaterMeterAfter { get; set; }
    public int? ElectricityMeterAfter { get; set; }
    public int FlatTypeId { get; set; }
    public int BuildingId { get; set; }
}