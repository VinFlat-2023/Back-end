using Domain.ViewModel.ServiceTypeEntity;

namespace Domain.ViewModel.ServiceEntity;

public class ServiceBasicDetailEntity
{
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public decimal? Amount { get; set; }
    public int ServiceTypeId { get; set; }
    public ServiceTypeDetailEntity ServiceType { get; set; }
}