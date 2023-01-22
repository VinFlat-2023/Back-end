using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Area
{
    public Area()
    {
        Buildings = new HashSet<Building>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AreaId { get; set; }

    public string Name { get; set; }
    public string Location { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Building> Buildings { get; set; }
}