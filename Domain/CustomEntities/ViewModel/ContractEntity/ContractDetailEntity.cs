using Domain.CustomEntities.ViewModel.BuildingEntity;
using Domain.CustomEntities.ViewModel.RenterEntity;

namespace Domain.CustomEntities.ViewModel.ContractEntity;

public class ContractDetailEntity
{
    public virtual ContractEntity Contract { get; set; } = null!;
    public virtual BuildingManagerEntity Building { get; set; } = null!;
    public virtual RenterProfileEntity Renter { get; set; } = null!;
}