namespace Domain.QueryFilter;

public class AreaFilter : PagingFilter
{
    public string? Name { get; set; }

    //public string? Location { get; set; }
    public bool? Status { get; set; }
}