using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RoomTypeDTO;

public class RoomTypeDto
{
    public int RoomTypeId { get; set; }
    [JsonIgnore] public string? Description { get; set; }
    [JsonIgnore] public bool IsDeletable { get; set; }
    [JsonIgnore] public int NumberOfSlots { get; set; }
    public int NumberOfSlotsAvailable { get; set; }
}