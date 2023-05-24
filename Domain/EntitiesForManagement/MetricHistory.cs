namespace Domain.EntitiesForManagement;

public class MetricHistory
{
    public int MetricHistoryId { get; set; }

    public int? WaterMeterBefore { get; set; }

    public int? WaterMeterAfter { get; set; }

    public int? ElectricityMeterBefore { get; set; }

    public int? ElectricityMeterAfter { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? RecordedDate { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int FlatId { get; set; }

    public virtual Flat Flat { get; set; }
}