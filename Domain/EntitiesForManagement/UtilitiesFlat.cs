namespace Domain.EntitiesForManagement;

public class UtilitiesFlat
{
    public int UtilitiesFlatId { get; set; }
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; } 
    public int UtilitiesId { get; set; }
    public virtual Utility Utility { get; set; } 
}