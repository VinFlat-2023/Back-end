using Domain.EntitiesDTO.RequestTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RequestDTO;

public class RequestDto
{
    public int RequestId { get; set; }
    public string? RequestName { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string Status { get; set; } = null!;
    public int? RequestTypeId { get; set; }

    [JsonIgnore] public virtual RequestTypeDto RequestType { get; set; } = null!;
}