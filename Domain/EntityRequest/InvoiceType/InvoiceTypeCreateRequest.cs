using System.ComponentModel.DataAnnotations;

namespace Domain.EntityRequest.InvoiceType;

public class InvoiceTypeCreateRequest
{
    // Expense type here
    // for example: "Rent", "Electricity", "Water", "Internet", "Gas", "Phone", "Other"
    [Required] public string InvoiceTypeName { get; set; } = null!;

    [Required] public bool Status { get; set; }
}