namespace Domain.EntityRequest.Invoice;

public class MassInvoiceCreateRequest
{
    public string Name { get; set; } = null!;

    public string? Detail { get; set; }

    // Receiver employee
    public int RenterId { get; set; }

    // Management employee
    public int EmployeeId { get; set; }

    // Invoice type
    public int InvoiceTypeId { get; set; }
}