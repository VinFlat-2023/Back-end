using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class InvoiceDetailFilterRequest : PagingFilter
{
    public decimal? Amount { get; set; }

    public int? InvoiceId { get; set; }

    public int? ServiceId { get; set; }
}