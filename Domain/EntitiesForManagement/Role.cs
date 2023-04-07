using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class Role
{
    public Role()
    {
        Employees = new HashSet<Employee>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RoleId { get; set; }

    public string RoleName { get; set; }
    public bool Status { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
}