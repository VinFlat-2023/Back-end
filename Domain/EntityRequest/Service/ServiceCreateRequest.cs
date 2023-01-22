namespace Domain.EntityRequest.Service;

public class ServiceCreateRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool Status { get; set; }
    public decimal? Amount { get; set; }
    public int ServiceTypeId { get; set; }
}