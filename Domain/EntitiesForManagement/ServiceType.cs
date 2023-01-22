using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.EntitiesForManagement;

public class ServiceType
{
    public ServiceType()
    {
        ServiceEntities = new HashSet<ServiceEntity>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceTypeId { get; set; }

    public string Name { get; set; }
    public string Status { get; set; }
    public virtual ICollection<ServiceEntity> ServiceEntities { get; set; }
}