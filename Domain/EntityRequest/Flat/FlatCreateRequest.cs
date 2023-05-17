namespace Domain.EntityRequest.Flat;

public class FlatCreateRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int FlatTypeId { get; set; }
    public List<int> RoomTypeId { get; set; }
    public string? FlatImageUrl1 { get; set; }
    public string? FlatImageUrl2 { get; set; }
    public string? FlatImageUrl3 { get; set; }
    public string? FlatImageUrl4 { get; set; }
    public string? FlatImageUrl5 { get; set; }
    public string? FlatImageUrl6 { get; set; }
}