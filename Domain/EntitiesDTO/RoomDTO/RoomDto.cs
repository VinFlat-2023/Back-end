using Domain.EntitiesDTO.FlatDTO;
using Domain.EntitiesDTO.RoomTypeDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.RoomDTO;

public class RoomDto
{
    public int RoomId { get; set; }
    public int FlatId { get; set; }
    [JsonIgnore] public virtual FlatDto Flat { get; set; }
    public int RoomTypeId { get; set; }
    public virtual RoomTypeDto RoomType { get; set; }
}