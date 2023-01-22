namespace Domain.QueryFilter;

public class FlatFilter : PagingFilter
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Status { get; set; }
    public int? FlatTypeId { get; set; }
    public int? BuildingId { get; set; }
}