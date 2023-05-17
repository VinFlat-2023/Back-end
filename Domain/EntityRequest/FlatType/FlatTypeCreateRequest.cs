namespace Domain.EntityRequest.FlatType;

public class FlatTypeCreateRequest
{
    public string FlatTypeName { get; set; }
    public int RoomCapacity { get; set; }
    public bool Status { get; set; }
}