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

    public int? TotalFloor { get; set; }

    public int? TotalRooms { get; set; }

    public int? CoordinateX { get; set; }

    public int? CoordinateY { get; set; }

    public bool Status { get; set; }

    public int AreaId { get; set; }

    [JsonIgnore] public int AccountId { get; set; }

    [JsonIgnore] public AccountDto Account { get; set; }

    public AreaDto Area { get; set; }

    [JsonIgnore] public virtual ICollection<FlatDto> Flats { get; set; }
}