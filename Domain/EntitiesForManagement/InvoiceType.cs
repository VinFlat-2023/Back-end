namespace Domain.EntitiesForManagement;

public class InvoiceType
{
    public int InvoiceTypeId { get; set; }
    public string InvoiceTypeName { get; set; } = null!;
    public bool Status { get; set; }
}