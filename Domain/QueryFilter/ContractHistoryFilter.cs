namespace Domain.QueryFilter;

public class ContractHistoryFilter : PagingFilter
{
    public int? RenterId { get; set; }

    public int? ContractId { get; set; }

    public string? ContractName { get; set; }

    public string? ContractStatus { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DateSigned { get; set; }

    public DateTime? EndDate { get; set; }
}