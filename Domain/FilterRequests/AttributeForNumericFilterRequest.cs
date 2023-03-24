using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class AttributeForNumericFilterRequest : PagingFilter
{
    public string? ElectricityAttribute { get; set; }
    public string? WaterAttribute { get; set; }
}