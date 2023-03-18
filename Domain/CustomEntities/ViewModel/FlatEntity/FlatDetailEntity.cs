namespace Domain.CustomEntities.ViewModel.FlatEntity;

public class FlatDetailEntity
{
    public int? WaterMeterAfter { get; set; }
    public int? ElectricityMeterAfter { get; set; }
    public decimal PriceForRent { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
}