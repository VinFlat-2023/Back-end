namespace Domain.QueryFilter;

public class InvoiceTypeFilter : PagingFilter
{
    public string? InvoiceTypeName { get; set; }

    public bool? Status { get; set; }
}