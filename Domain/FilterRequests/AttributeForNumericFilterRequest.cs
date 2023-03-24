using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class AttributeForNumericFilterRequest : PagingFilter
{
    public int? ElectricityAttribute { get; set; }
    public int? WaterAttribute { get; set; }
}