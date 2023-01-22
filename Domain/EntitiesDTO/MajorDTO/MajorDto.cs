using Domain.EntitiesDTO.RenterDTO;
using Domain.EntitiesDTO.UniversityDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.MajorDTO;

public class MajorDto
{
    public int? MajorId { get; set; }

    public string? Name { get; set; }

    public int UniversityId { get; set; }

    [JsonIgnore] public virtual RenterDto? Renter { get; set; }

    [JsonIgnore] public virtual UniversityDto University { get; set; } = null!;
}