using Domain.CustomEntities.ViewModel.BuildingEntity;
using Domain.CustomEntities.ViewModel.FlatEntity;

namespace Domain.CustomEntities.ViewModel.RentalEntity;

public class RentalDetailEntity
{
    public string FlatName { get; set; }
    public BuildingManagerEntity BuildingManagerEntity { get; set; }
    public FlatDetailEntity FlatEntity { get; set; }
}