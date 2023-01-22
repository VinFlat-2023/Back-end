namespace Domain.QueryFilter;

public class MajorFilter : PagingFilter
{
    public string? Name { get; set; }

    public int? UniversityId { get; set; }
}