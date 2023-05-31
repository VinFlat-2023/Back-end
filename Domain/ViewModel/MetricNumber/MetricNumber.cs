namespace Domain.ViewModel.MetricNumber;

public class MetricNumber
{
    public decimal WaterMeterBefore { get; set; }
    public decimal WaterMeterAfter { get; set; }
    public decimal ElectricityMeterBefore { get; set; }
    public decimal ElectricityMeterAfter { get; set; }
    public decimal UsedWaterNumber => WaterMeterAfter - WaterMeterBefore;
    public decimal UsedElectricityNumber => ElectricityMeterAfter - ElectricityMeterBefore;
    public string? LastFetch { get; set; }
}