using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.CustomAttribute;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Invoice;

public class InvoiceUpdateRequest
{
    public string Name { get; set; } 
    public bool Status { get; set; }
    public DateTime? DueDate { get; set; }
    public string Detail { get; set; }
    public DateTime? PaymentTime { get; set; }
    public int RenterId { get; set; }
    public int EmployeeId { get; set; }
    public int InvoiceTypeId { get; set; }
}