namespace Domain.EntityRequest.Contract;

public class ContractUpdateRequest
{
    public string ContractName { get; set; }
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public string Description { get; set; }
    public DateTime EndDate { get; set; }
    public string? ContractStatus { get; set; }
    public string PriceForWater { get; set; }
    public string PriceForElectricity { get; set; }
    public string PriceForService { get; set; }
    public string PriceForRent { get; set; }
}