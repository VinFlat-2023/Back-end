using Domain.EntitiesDTO.ServiceDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.ServiceTypeDTO;

public class ServiceTypeDto
{
    public int ServiceTypeId { get; set; }
    public string Name { get; set; } = null!;
    public string Status { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<ServiceEntityDto>? ServiceEntities { get; set; }
}