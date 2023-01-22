using Domain.EntitiesDTO.FlatDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.FlatTypeDTO;

public class FlatTypeDto
{
    public int FlatTypeId { get; set; }
    public int? Capacity { get; set; }
    public string? Status { get; set; }

    [JsonIgnore] public virtual ICollection<FlatDto> Flats { get; set; }
}