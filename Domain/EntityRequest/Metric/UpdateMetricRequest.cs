namespace Domain.EntityRequest.Metric;

public class UpdateMetricRequest
{
    public decimal WaterMeterBefore { get; set; }
    public decimal WaterMeterAfter { get; set; }
    public decimal ElectricityMeterBefore { get; set; }
    public decimal ElectricityMeterAfter { get; set; }
}