namespace Domain.EntityRequest.InvoiceDetail;

public class InvoiceDetailCreateRequest
{
    public int InvoiceDetailId { get; set; }

    public decimal Amount { get; set; }

    public int InvoiceId { get; set; }
}