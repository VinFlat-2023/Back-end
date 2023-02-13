namespace Domain.EntityRequest.Invoice;

public class MassInvoiceCreateRequest
{
    public string Name { get; set; } = null!;

    public string? Detail { get; set; }

    // Receiver account
    public int RenterId { get; set; }

    // Management account
    public int AccountId { get; set; }

    // Invoice type
    public int InvoiceTypeId { get; set; }
}