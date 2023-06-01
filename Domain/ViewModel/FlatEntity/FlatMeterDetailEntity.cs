namespace Domain.ViewModel.FlatEntity;

public class FlatMeterDetailEntity
{
    public string WaterMeterAfter { get; set; }
    public string ElectricityMeterAfter { get; set; }
    public string WaterMeterBefore { get; set; }
    public string ElectricityMeterBefore { get; set; }
    public string PriceForRent { get; set; }
    public string PriceForWater { get; set; }
    public string PriceForElectricity { get; set; }
    public string PriceForService { get; set; }
}