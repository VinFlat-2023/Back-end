namespace Domain.QueryFilter;

public class TicketTypeFilter : PagingFilter
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }
}