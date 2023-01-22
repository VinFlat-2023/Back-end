namespace Domain.EntityRequest.Major;

public class MajorCreateRequest
{
    public string Name { get; set; } = null!;
    public int UniversityId { get; set; }
}