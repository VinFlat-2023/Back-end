namespace Domain.EntityRequest.Area;

public class AreaCreateRequest
{
    public string Name { get; set; } = null!;

    //public string Location { get; set; } = null!;
    public bool Status { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public string? ImageUrl4 { get; set; }
}