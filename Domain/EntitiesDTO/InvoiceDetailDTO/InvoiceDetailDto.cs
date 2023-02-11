using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.ServiceDTO;
using Domain.EntitiesDTO.TicketDTO;

namespace Domain.EntitiesDTO.InvoiceDetailDTO;

public class InvoiceDetailDto
{
    public int InvoiceDetailId { get; set; }
    public double Amount { get; set; }
    public int InvoiceId { get; set; }

    public virtual InvoiceDto Invoice { get; set; } = null!;

    public int? ServiceId { get; set; }

    public virtual ServiceEntityDto? Services { get; set; }

    public int? TicketId { get; set; }

    public virtual TicketDto? Ticket { get; set; }
}