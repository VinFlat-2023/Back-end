using Domain.EntitiesDTO.BuildingDTO;
using Domain.EntitiesDTO.ContractDTO;
using Domain.EntitiesDTO.FeedbackDTO;
using Domain.EntitiesDTO.FlatTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.FlatDTO;

public class FlatDto
{
    public int FlatId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    // total of the flat
    public int? TotalWaterMeter { get; set; }

    // new input
    public int? WaterMeter { get; set; }

    // total of the flat
    public int? TotalElectricityMeter { get; set; }

    // new input
    public int? ElectricityMeter { get; set; }

    public int FlatTypeId { get; set; }

    public virtual FlatTypeDto FlatType { get; set; }

    public int BuildingId { get; set; }

    public virtual BuildingDto Building { get; set; }

    [JsonIgnore] public virtual ICollection<FeedbackDto> FeedBacks { get; set; }

    [JsonIgnore] public virtual ICollection<ContractDto> Contracts { get; set; }
}