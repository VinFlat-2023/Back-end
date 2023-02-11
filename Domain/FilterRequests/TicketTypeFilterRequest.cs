using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class TicketTypeFilterRequest : PagingFilter
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }
}