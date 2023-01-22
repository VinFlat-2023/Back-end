using Domain.EntitiesDTO.BuildingDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.AreaDTO;

public class AreaDto
{
    public int AreaId { get; set; }

    public string? Name { get; set; }

    public string? Location { get; set; }

    public bool? Status { get; set; }

    [JsonIgnore] public virtual ICollection<BuildingDto> Buildings { get; set; }
}