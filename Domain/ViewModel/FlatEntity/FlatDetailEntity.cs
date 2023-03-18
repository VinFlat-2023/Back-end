namespace Domain.ViewModel.FlatEntity;

public class FlatDetailEntity
{
    public int? WaterMeterAfter { get; set; }
    public int? ElectricityMeterAfter { get; set; }
    public string PriceForRent { get; set; } = null!;
    public string PriceForWater { get; set; } = null!;
    public string PriceForElectricity { get; set; } = null!;
    public string PriceForService { get; set; } = null!;
}