namespace Domain.EntityRequest.Room;

public class RoomUpdateRequest
{
    public string RoomName { get; set; }
    public decimal ElectricityAttribute { get; set; }
    public decimal WaterAttribute { get; set; }
    public int RoomTypeId { get; set; }
    public string Status { get; set; }
    public int? FlatId { get; set; }
    public string? RoomImageUrl1 { get; set; }
    public string? RoomImageUrl2 { get; set; }
    public string? RoomImageUrl3 { get; set; }
    public string? RoomImageUrl4 { get; set; }
    public string? RoomImageUrl5 { get; set; }
    public string? RoomImageUrl6 { get; set; }
}