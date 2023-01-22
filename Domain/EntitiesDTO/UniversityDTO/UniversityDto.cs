using Domain.EntitiesDTO.MajorDTO;
using Newtonsoft.Json;

namespace Domain.EntitiesDTO.UniversityDTO;

public class UniversityDto
{
    public int? UniversityId { get; set; }

    public string? UniversityName { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }

    [JsonIgnore] public virtual ICollection<MajorDto>? Majors { get; set; }
}