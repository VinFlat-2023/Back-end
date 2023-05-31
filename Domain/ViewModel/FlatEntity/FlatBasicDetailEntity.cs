namespace Domain.ViewModel.FlatEntity;

public class FlatBasicDetailEntity
{
    public int FlatId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public decimal WaterMeterBefore { get; set; }
    public decimal WaterMeterAfter { get; set; }
    public decimal ElectricityMeterBefore { get; set; }
    public decimal ElectricityMeterAfter { get; set; }
    public string? FlatImageUrl1 { get; set; }
    public string? FlatImageUrl2 { get; set; }
    public string? FlatImageUrl3 { get; set; }
    public string? FlatImageUrl4 { get; set; }
    public string? FlatImageUrl5 { get; set; }
    public string? FlatImageUrl6 { get; set; }
}