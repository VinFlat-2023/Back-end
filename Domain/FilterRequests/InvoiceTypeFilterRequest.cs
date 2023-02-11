using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class InvoiceTypeFilterRequest : PagingFilter
{
    public string? InvoiceTypeName { get; set; }

    public bool? Status { get; set;
}
}