using Domain.EntitiesDTO.InvoiceDetailDTO;
using Domain.EntitiesDTO.ServiceTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.ServiceDTO;

public class ServiceEntityDto
{
    public int ServiceId { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public virtual ICollection<InvoiceDetailDto> InvoiceDetails { get; set; } = null!;
    public double? Amount { get; set; }
    public int? ServiceTypeId { get; set; }

    [JsonIgnore] public virtual ServiceTypeDto ServiceType { get; set; }
}