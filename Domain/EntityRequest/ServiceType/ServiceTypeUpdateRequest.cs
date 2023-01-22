namespace Domain.EntityRequest.ServiceType;

public class ServiceTypeUpdateRequest
{
    public int ServiceTypeId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
}