using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Major
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MajorId { get; set; }

    public string Name { get; set; } = null!;

    public int UniversityId { get; set; }

    public virtual University University { get; set; } = null!;

    public virtual Renter? Renter { get; set; }
}