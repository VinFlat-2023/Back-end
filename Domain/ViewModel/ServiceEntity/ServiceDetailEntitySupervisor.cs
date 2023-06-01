using System.Globalization;
using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.ServiceTypeEntity;

namespace Domain.ViewModel.ServiceEntity;

public class ServiceDetailEntitySupervisor
{
    public int ServiceId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Status { get; set; }
    public decimal Price { get; set; }
    public string ServicePrice => Price.ToString(CultureInfo.InvariantCulture);
    public int BuildingId { get; set; }
    public BuildingBasicDetailEntity Building { get; set; }
    public int ServiceTypeId { get; set; }
    public ServiceTypeDetailEntity ServiceType { get; set; }
}