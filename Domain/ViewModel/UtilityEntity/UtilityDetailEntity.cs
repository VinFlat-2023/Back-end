using Domain.ViewModel.UtilitiesFlatEntity;

namespace Domain.ViewModel.UtilityEntity;

public class UtilityDetailEntity
{
    public int UtilitiesId { get; set; }
    public string UtilitiesName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<UtilitiesFlatDetailEntity> UtilitiesFlats { get; set; }
}