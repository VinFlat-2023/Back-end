using System.Globalization;

namespace Domain.ViewModel.ServiceEntity;

public class ServiceDetailEmailEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ServicePrice => Price.ToString(CultureInfo.InvariantCulture);
}