using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.UtilityEntity;

namespace Domain.ViewModel.UtilitiesFlatEntity;

public class UtilitiesFlatDetailEntity
{
    public int UtilitiesFlatId { get; set; }
    public int FlatId { get; set; }
    public virtual FlatDetailEntity Flat { get; set; }
    public int UtilityId { get; set; }
    public virtual UtilityDetailEntity Utility { get; set; }
}