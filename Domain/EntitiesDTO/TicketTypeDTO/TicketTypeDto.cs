using Domain.EntitiesDTO.TicketDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.TicketTypeDTO;

public class TicketTypeDto
{
    public int TicketTypeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }

    [JsonIgnore] public virtual ICollection<TicketDto> Requests { get; set; }
}