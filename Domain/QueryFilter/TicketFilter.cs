namespace Domain.QueryFilter;

public class TicketFilter : PagingFilter
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
    public int? AccountId { get; set; }
    public string? FullName { get; set; }
}