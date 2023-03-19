using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.RenterEntity;

namespace Domain.ViewModel.ContractEntity;

public class ContractDetailEntity
{
    public virtual ContractEntity Contract { get; set; } = null!;
    public virtual BuildingContractDetailEntity Building { get; set; } = null!;
    public virtual RenterProfileEntity Renter { get; set; } = null!;
}