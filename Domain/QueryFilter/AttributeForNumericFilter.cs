namespace Domain.QueryFilter;

public class AttributeForNumericFilter : PagingFilter
{
    public int? ElectricityAttribute { get; set; }
    public int? WaterAttribute { get; set; }
}