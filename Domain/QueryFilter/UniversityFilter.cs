namespace Domain.QueryFilter;

public class UniversityFilter : PagingFilter
{
    public string? UniversityName { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public string? Address { get; set; }
}