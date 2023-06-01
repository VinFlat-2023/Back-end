namespace Domain.EntityRequest.Invoice;

public class InvoiceUpdateRequest
{
    public string Name { get; set; }
    public string Status { get; set; }
    public DateTime DueDate { get; set; }
    public string Detail { get; set; }
    public DateTime? PaymentTime { get; set; }
}