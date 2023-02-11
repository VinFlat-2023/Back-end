namespace Domain.EntityRequest.FlatType;

public class FlatTypeCreateRequest
{
    public int RoomCapacity { get; set; }
    public string Status { get; set; } = null!;
}