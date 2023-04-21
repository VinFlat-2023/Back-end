namespace Domain.EntityRequest.Invoice;

public class InvoiceCreateRequest
{
    public string Name { get; set; } = null!;
    public bool? Status { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Detail { get; set; }
    public int RenterId { get; set; }
    public int InvoiceTypeId { get; set; }
}