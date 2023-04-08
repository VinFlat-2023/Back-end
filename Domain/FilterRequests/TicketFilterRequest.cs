using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class TicketFilterRequest : PagingFilter
{
    public string? Description { get; set; }
    public DateTime? CreateDate { get; set; }
    public DateTime? SolveDate { get; set; }
    public decimal? Amount { get; set; }
    public string? Status { get; set; }
    public int? TicketTypeId { get; set; }
    public string? TicketTypeName { get; set; }
    public int? ContractId { get; set; }
    public string? ContractName { get; set; }
    public int? EmployeeId { get; set; }
    public string? FullName { get; set; }
}