using Domain.ViewModel.FlatEntity;

namespace Domain.ViewModel.MetricNumber;

public class MetricNumberForFlat
{
    public decimal? WaterNumber { get; set; }
    public decimal? ElectricityNumber { get; set; }
    public string? LastFetch { get; set; }
    public int FlatId { get; set; }
    public FlatBasicDetailEntity Flat { get; set; }
}