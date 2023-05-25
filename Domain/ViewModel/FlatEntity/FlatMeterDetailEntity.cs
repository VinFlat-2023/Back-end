namespace Domain.ViewModel.FlatEntity;

public class FlatMeterDetailEntity
{
    public decimal WaterMeterAfter { get; set; }
    public decimal ElectricityMeterAfter { get; set; }
    public string PriceForRent { get; set; } = null!;
    public string PriceForWater { get; set; } = null!;
    public string PriceForElectricity { get; set; } = null!;
    public string PriceForService { get; set; } = null!;
}