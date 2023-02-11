using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.Request;

public class TicketCreateRequest
{
    public string TicketName { get; set; } = null!;
    public string Description { get; set; } = null!;

    [Required] public DateTime CreateDate { get; set; }

    public DateTime? SolveDate { get; set; }
    public double? Amount { get; set; }
    public string Status { get; set; } = null!;
    [Required] public int TicketTypeId { get; set; }
}