using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.RenterEntity;

namespace Domain.ViewModel.ContractEntity;

public class ContractDetailEntity
{
    public ContractMeterDetailEntity ContractMeterDetail { get; set; }
    public BuildingContractDetailEntity Building { get; set; }
    public RenterProfileEntity Renter { get; set; }
}