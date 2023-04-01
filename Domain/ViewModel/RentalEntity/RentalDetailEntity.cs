using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.RenterEntity;
using Domain.ViewModel.ServiceEntity;

namespace Domain.ViewModel.RentalEntity;

public class RentalDetailEntity
{
    public string FlatName { get; set; }
    public BuildingContractDetailEntity BuildingDetailEntity { get; set; }
    public FlatMeterDetailEntity FlatMeterEntity { get; set; }
    public ICollection<ServiceBasicDetailEntity> Services { get; set; }
    public ICollection<RenterBasicDetailEntity> Renters { get; set; }
}