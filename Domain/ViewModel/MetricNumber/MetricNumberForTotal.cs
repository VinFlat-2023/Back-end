namespace Domain.ViewModel.MetricNumber;

public class MetricNumberForTotal
{
    public decimal? TotalWaterNumber { get; set; }
    public decimal? TotalElectricityNumber { get; set; }
    public string? LastFetch { get; set; }
}