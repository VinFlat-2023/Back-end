namespace Domain.EntitiesForManagement;

public class Utility
{
    public Utility()
    {
        UtilitiesFlats = new HashSet<UtilitiesFlat>();
    }
    public int UtilitiesId { get; set; }
    public string UtilitiesName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<UtilitiesFlat> UtilitiesFlats { get; set; }
}