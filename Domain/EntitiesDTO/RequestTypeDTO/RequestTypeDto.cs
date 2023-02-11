using Domain.EntitiesDTO.RequestDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RequestTypeDTO;

public class RequestTypeDto
{
    public int TicketTypeId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }

    [JsonIgnore] public virtual ICollection<RequestDto> Requests { get; set; }
}