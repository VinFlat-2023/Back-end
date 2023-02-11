using Domain.EntitiesDTO.RequestTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RequestDTO;

public class RequestDto
{
    public int TicketId { get; set; }
    public string? TicketName { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public double? Amount { get; set; }
    public string Status { get; set; } = null!;
    public int? TicketTypeId { get; set; }

    [JsonIgnore] public virtual RequestTypeDto RequestType { get; set; } = null!;
}