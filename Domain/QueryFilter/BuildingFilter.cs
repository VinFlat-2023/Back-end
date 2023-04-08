namespace Domain.QueryFilter;

public class BuildingFilter : PagingFilter
{
    public string? BuildingName { get; set; }
    public string? Description { get; set; }
    public int? TotalFlats { get; set; }
    public bool? Status { get; set; }
    public string? BuildingPhoneNumber { get; set; }
    public string? BuildingAddress { get; set; }
    public string? AreaName { get; set; }
    public string? EmployeeName { get; set; }
}