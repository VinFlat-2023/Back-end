namespace Domain.EntityRequest.Area;

public class AreaUpdateRequest
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public bool Status { get; set; }
}