namespace Domain.EntityRequest.InvoiceDetail;

public class InvoiceDetailCreateRequest
{
    public decimal Amount { get; set; }
    public int InvoiceId { get; set; }
}