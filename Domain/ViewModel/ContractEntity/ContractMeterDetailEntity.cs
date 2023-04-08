namespace Domain.ViewModel.ContractEntity;

public class ContractMeterDetailEntity
{
    public int ContractId { get; set; }
    public string ContractName { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public string? ImageUrl { get; set; }
    public string PriceForRent { get; set; }
    public string PriceForWater { get; set; }
    public string PriceForElectricity { get; set; }
    public string PriceForService { get; set; }

    // TODO : Add Flat
}