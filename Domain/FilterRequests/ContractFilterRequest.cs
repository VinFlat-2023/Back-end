using Domain.QueryFilter;

namespace Domain.FilterRequests;

public class ContractFilterRequest : PagingFilter
{
    public string? ContractName { get; set; }

    public DateTime? DateSigned { get; set; }

    public DateTime? StartDate { get; set; }

    public string? Description { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? LastUpdated { get; set; }

    public decimal? PriceForWater { get; set; }

    public decimal? PriceForElectricity { get; set; }

    public decimal? PriceForService { get; set; }

    public string? ContractStatus { get; set; }

    public decimal? PriceForRent { get; set; }

    public int? RenterId { get; set; }

    public string? RenterUsername { get; set; }

    public string? RenterPhoneNumber { get; set; }

    public string? RenterEmail { get; set; }

    public string? RenterFullname { get; set; }
}