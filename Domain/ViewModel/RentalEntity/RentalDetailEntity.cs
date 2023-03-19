using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.FlatEntity;

namespace Domain.ViewModel.RentalEntity;

public class RentalDetailEntity
{
    public string FlatName { get; set; }
    public BuildingContractDetailEntity BuildingDetailEntity { get; set; }
    public FlatMeterDetailEntity FlatMeterEntity { get; set; }
}