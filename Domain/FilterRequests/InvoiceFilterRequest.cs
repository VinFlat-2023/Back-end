using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class InvoiceFilterRequest : PagingFilter
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

    public int? AccountId { get; set; }

    public string? AccountName { get; set; }

    public int? InvoiceTypeId { get; set; }
}