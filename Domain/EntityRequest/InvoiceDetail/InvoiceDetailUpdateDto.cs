namespace Domain.EntityRequest.InvoiceDetail;

public class InvoiceDetailUpdateRequest
{
    public decimal Amount { get; set; }

    public int InvoiceId { get; set; }
}