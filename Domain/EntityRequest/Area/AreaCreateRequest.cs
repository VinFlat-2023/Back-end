namespace Domain.EntityRequest.Area;

public class AreaCreateRequest
{
    public string Name { get; set; } = null!;
    public string Location { get; set; } = null!;
    public bool Status { get; set; }
}