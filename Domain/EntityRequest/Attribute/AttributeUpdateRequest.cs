namespace Domain.EntityRequest.Attribute;

public class AttributeUpdateRequest
{
    public int AttributeForNumericId { get; set; }
    public string ElectricityAttribute { get; set; }
    public string WaterAttribute { get; set; }
}