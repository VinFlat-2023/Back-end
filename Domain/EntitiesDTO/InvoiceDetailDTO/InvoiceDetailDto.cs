using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.ServiceDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.InvoiceDetailDTO;

public class InvoiceDetailDto
{
    public int InvoiceDetailId { get; set; }
    public double Amount { get; set; }
    public int InvoiceId { get; set; }

    [JsonIgnore] public virtual InvoiceDto Invoice { get; set; } = null!;

    public int? ServiceId { get; set; }

    [JsonIgnore] public virtual ServiceEntityDto? Services { get; set; }
}