namespace Domain.QueryFilter;

public class InvoiceDetailFilter : PagingFilter
{
    public double? Amount { get; set; }

    public int? InvoiceId { get; set; }

    public int? ServiceId { get; set; }
}