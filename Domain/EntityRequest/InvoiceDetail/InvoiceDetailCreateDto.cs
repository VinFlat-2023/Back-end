namespace Domain.EntityRequest.InvoiceDetail;

public class InvoiceDetailCreateRequest
{
    public double Amount { get; set; }
    public int InvoiceId { get; set; }
}