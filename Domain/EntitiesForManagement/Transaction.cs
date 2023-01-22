namespace Domain.EntitiesForManagement;

public class Transaction
{
    public int TransactionId { get; set; }
    public string? TpTransId { get; set; }
    public DateTime TransactionTime { get; set; }
    public int InvoiceId { get; set; }
    public virtual Invoice Invoice { get; set; }
    public int Status { get; set; }
}