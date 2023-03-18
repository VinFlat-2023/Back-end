using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.ServiceTypeEntity;

namespace Domain.ViewModel.ServiceEntity;

public class ServiceDetailEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public decimal? Amount { get; set; }
    public BuildingServiceDetailEntity Building { get; set; }
    public ServiceTypeDetailEntity ServiceType { get; set; }
}