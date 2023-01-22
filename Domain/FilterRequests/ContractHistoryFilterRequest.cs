using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class ContractHistoryFilterRequest : PagingFilter
{
    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? ContractHistoryStatus { get; set; }

    public DateTime? ContractExpiredDate { get; set; }

    public int? ContractId { get; set; }
}