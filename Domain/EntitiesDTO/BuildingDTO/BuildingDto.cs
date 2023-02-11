using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesDTO.AreaDTO;
using Domain.EntitiesDTO.FlatDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.BuildingDTO;

public class BuildingDto
{
    public int BuildingId { get; set; }

    public string BuildingName { get; set; } = null!;

    public string? Description { get; set; }

    public int? TotalRooms { get; set; }
    public string? ImageUrl { get; set; }

    public double? CoordinateX { get; set; }

    public double? CoordinateY { get; set; }

    public bool Status { get; set; }

    public int AreaId { get; set; }

    public int AccountId { get; set; }

    public virtual AccountDto Account { get; set; } = null!;

    public virtual AreaDto Area { get; set; } = null!;

    [JsonIgnore] public virtual ICollection<FlatDto> Flats { get; set; }
}