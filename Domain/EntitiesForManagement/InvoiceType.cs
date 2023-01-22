namespace Domain.EntitiesForManagement;

public class InvoiceType
{
    public int InvoiceTypeId { get; set; }

    // Expense type name here : Thu / Chi / Còn lại
    public string InvoiceTypeName { get; set; } = null!;
    public bool Status { get; set; }
}