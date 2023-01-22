namespace Domain.QueryFilter;

public class InvoiceDetailFilter : PagingFilter
{
    public decimal? Amount { get; set; }

    public int? InvoiceId { get; set; }

    public int? ServiceId { get; set; }
}