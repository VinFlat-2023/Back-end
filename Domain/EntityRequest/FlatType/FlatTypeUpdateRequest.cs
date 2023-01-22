namespace Domain.EntityRequest.FlatType;

public class FlatTypeUpdateRequest
{
    public int FlatTypeId { get; set; }
    public int Capacity { get; set; }
    public string Status { get; set; }
}