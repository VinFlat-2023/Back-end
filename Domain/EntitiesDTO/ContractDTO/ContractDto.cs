namespace Domain.EntitiesDTO.ContractDTO;

public class ContractDto
{
    public int ContractId { get; set; }

    public string? ContractName { get; set; }

    public DateTime? DateSigned { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? Description { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? LastUpdated { get; set; }

    public decimal? PriceForWater { get; set; }

    public decimal? PriceForElectricity { get; set; }

    public decimal? PriceForService { get; set; }

    public string? ContractStatus { get; set; }

    public string? ImageUrl { get; set; }

    public decimal? PriceForRent { get; set; }
}