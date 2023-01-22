namespace Domain.EntityRequest.Major;

public class MajorUpdateRequest
{
    public int MajorId { get; set; }
    public string Name { get; set; }
    public int UniversityId { get; set; }
}