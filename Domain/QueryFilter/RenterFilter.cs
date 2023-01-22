namespace Domain.QueryFilter;

public class RenterFilter : PagingFilter
{
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? FullName { get; set; }
    public bool? Status { get; set; }
    public string? Address { get; set; }
    public string? Gender { get; set; }
    public int? MajorId { get; set; }
    public int? UniversityId { get; set; }
    public int? ContractId { get; set; }
}