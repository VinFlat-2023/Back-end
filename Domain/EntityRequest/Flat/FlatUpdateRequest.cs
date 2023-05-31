namespace Domain.EntityRequest.Flat;

public class FlatUpdateRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; } = null!;
    public int FlatTypeId { get; set; }
    public int BuildingId { get; set; }
    public string? ImageUrl { get; set; }
    public string? ImageUrl2 { get; set; }
    public string? ImageUrl3 { get; set; }
    public string? ImageUrl4 { get; set; }
    public string? ImageUrl5 { get; set; }
    public string? ImageUrl6 { get; set; }
}