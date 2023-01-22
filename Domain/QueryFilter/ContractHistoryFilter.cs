namespace Domain.QueryFilter;

public class ContractHistoryFilter : PagingFilter
{
    public decimal? Price { get; set; }
    public string? Description { get; set; }
    public string? ContractHistoryStatus { get; set; }

    public DateTime? ContractExpiredDate { get; set; }
    public int? ContractId { get; set; }
}