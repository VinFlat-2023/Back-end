namespace Domain.CustomEntities.RentalEntity;

public class RentalDetailEntity
{
    public string FlatName { get; set; }
    public BuildingRentalEntity BuildingRentalEntity { get; set; }
    public FlatRentalEntity FlatRentalEntity { get; set; }
}