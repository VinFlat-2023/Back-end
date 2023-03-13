namespace Domain.CustomEntities.RentalEntity;

public class RentalDetailEntity
{
    public decimal PriceForRent { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
    public string FlatName { get; set; }
    public string BuildingName { get; set; } 
    public FlatRentalEntity FlatRentalEntity { get; set; }
}