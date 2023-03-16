namespace Domain.CustomEntities.RentalEntity;

public class FlatRentalEntity
{
    public int? WaterMeterAfter { get; set; }
    public int? ElectricityMeterAfter { get; set; }
    public decimal PriceForRent { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
}