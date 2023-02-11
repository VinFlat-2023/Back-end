namespace Domain.EntityRequest.Service;

public class ServiceUpdateRequest
{
    public int ServiceId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
    public double? Amount { get; set; }
    public int ServiceTypeId { get; set; }
}