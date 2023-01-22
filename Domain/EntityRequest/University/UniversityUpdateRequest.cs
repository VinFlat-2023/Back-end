namespace Domain.EntityRequest.University;

public class UniversityUpdateRequest
{
    public int UniversityId { get; set; }
    public string? UniversityName { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public string? Address { get; set; }
}