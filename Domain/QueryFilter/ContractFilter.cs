namespace Domain.QueryFilter;

public class ContractFilter : PagingFilter
{
    public DateTime? DateSigned { get; set; }

    public DateTime? StartDate { get; set; }

    public string? Description { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? LastUpdated { get; set; }

    public string? ContractStatus { get; set; }

    public string? ImageUrl { get; set; }

    public double? Price { get; set; }

    public int? RenterId { get; set; }
}