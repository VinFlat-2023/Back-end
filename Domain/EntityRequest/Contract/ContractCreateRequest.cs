namespace Domain.EntityRequest.Contract;

public class ContractCreateRequest
{
    // Contract
    public string? ContractName { get; set; }
    public DateTime? DateSigned { get; set; }
    public DateTime? StartDate { get; set; }
    public string? Description { get; set; }
    public DateTime? EndDate { get; set; }
    public string? ContractStatus { get; set; }
    public string PriceForWater { get; set; }
    public string PriceForElectricity { get; set; }
    public string PriceForService { get; set; }
    public string PriceForRent { get; set; }
    public int FlatId { get; set; }
    public int RoomFlatId { get; set; }

    // Renter
    public string RenterUsername { get; set; }
    public string FullName { get; set; }
    public string RenterEmail { get; set; }
    public string RenterPhone { get; set; }
    public string RenterBirthDate { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
}