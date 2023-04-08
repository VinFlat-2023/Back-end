namespace Domain.QueryFilter;

public class InvoiceFilter : PagingFilter
{
    public string? Name { get; set; }
    public int? Amount { get; set; }
    public bool? Status { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Detail { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime? PaymentTime { get; set; }

    public DateTime? CreatedTime { get; set; }
    public int? RenterId { get; set; }
    public string? RenterName { get; set; }
    public int? EmployeeId { get; set; }
    public string? EmployeeName { get; set; }
    public int? InvoiceTypeId { get; set; }
}