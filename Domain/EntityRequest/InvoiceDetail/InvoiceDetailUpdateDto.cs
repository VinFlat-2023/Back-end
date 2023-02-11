namespace Domain.EntityRequest.InvoiceDetail;

public class InvoiceDetailUpdateRequest
{
    public int InvoiceDetailId { get; set; }

    public double Amount { get; set; }

    public int InvoiceId { get; set; }
}