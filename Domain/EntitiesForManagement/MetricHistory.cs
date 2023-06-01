namespace Domain.EntitiesForManagement;

public class MetricHistory
{
    public int MetricHistoryId { get; set; }

    public decimal WaterMeterBefore { get; set; }

    public decimal WaterMeterAfter { get; set; }

    public decimal ElectricityMeterBefore { get; set; }

    public decimal ElectricityMeterAfter { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? RecordedDate { get; set; }

    public int FlatId { get; set; }

    public virtual Flat Flat { get; set; }
}