namespace Domain.QueryFilter;

public class AttributeForNumericFilter : PagingFilter
{
    public string? ElectricityAttribute { get; set; }
    public string? WaterAttribute { get; set; }
}