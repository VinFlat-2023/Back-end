namespace Domain.QueryFilter;

public class ServiceEntityFilter : PagingFilter
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public decimal? Amount { get; set; }
    public int? ServiceTypeId { get; set; }
    public string? ServiceTypeName { get; set; }
    public int? BuildingId { get; set; }
    public string? BuildingName { get; set; }
}