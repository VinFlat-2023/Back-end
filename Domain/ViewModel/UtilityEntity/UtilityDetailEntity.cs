using Domain.ViewModel.UtilitiesFlatEntity;

namespace Domain.ViewModel.UtilityEntity;

public class UtilityDetailEntity
{
    public int UtilityId { get; set; }
    public string UtilitiesName { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<UtilitiesFlatDetailEntity> UtilitiesFlats { get; set; }
}