namespace Domain.CustomEntities.RentalEntity;

public class RentalDetailEntity
{
    public string FlatName { get; set; }
    public string BuildingName { get; set; }
    public FlatRentalEntity FlatRentalEntity { get; set; }
}