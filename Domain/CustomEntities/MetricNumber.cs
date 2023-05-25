namespace Domain.CustomEntities;

public class MetricNumber
{
    public decimal? WaterNumber { get; set; }
    public decimal? ElectricityNumber { get; set; }
    public string? LastFetch { get; set; }
}