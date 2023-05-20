namespace Domain.EntityRequest.Contract;

public class ContractCreateUserExistRequest
{
    public string ContractName { get; set; }
    public string DateSigned { get; set; }
    public string StartDate { get; set; }
    public string Description { get; set; }
    public string EndDate { get; set; }
    public string ContractStatus { get; set; }
    public string PriceForWater { get; set; }
    public string PriceForElectricity { get; set; }
    public string PriceForService { get; set; }
    public string PriceForRent { get; set; }
    public int FlatId { get; set; }
    public int RoomId { get; set; }
    public string? ContractImageUrl1 { get; set; }
    public string? ContractImageUrl2 { get; set; }
    public string? ContractImageUrl3 { get; set; }
    public string? ContractImageUrl4 { get; set; }
}