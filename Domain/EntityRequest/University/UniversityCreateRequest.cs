namespace Domain.EntityRequest.University;

public class UniversityCreateRequest
{
    public string UniversityName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Address { get; set; } = null!;
}