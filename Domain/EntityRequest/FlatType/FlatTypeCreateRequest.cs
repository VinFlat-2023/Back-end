namespace Domain.EntityRequest.FlatType;

public class FlatTypeCreateRequest
{
    public int Capacity { get; set; }
    public string Status { get; set; } = null!;
}