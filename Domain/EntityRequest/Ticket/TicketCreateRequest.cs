using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Ticket;

public class TicketCreateRequest
{
    public string Description { get; set; } = null!;
    [Required] public int TicketTypeId { get; set; }
    public string? ImageUrl { get; set; }
}