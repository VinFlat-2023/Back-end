namespace Domain.EntityRequest.InvoiceDetail;

public class InvoiceDetailUpdateRequest
{
    public double Amount { get; set; }

    public int InvoiceId { get; set; }
}