namespace Domain.EntityRequest.InvoiceType;

public class InvoiceTypeCreateRequest
{
    // Expense type here
    // for example: "Rent", "Electricity", "Water", "Internet", "Gas", "PhoneNumber", "Other"
    public string InvoiceTypeName { get; set; } = null!;

    public bool Status { get; set; }
}