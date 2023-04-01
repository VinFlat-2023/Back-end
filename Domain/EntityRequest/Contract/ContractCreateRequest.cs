namespace Domain.EntityRequest.Contract;

public class ContractCreateRequest
{
    // Contract
    public string? ContractName { get; set; }
    public string DateSigned { get; set; }
    public string StartDate { get; set; }
    public string? Description { get; set; }
    public string? EndDate { get; set; }
    public string? ContractStatus { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
    public decimal PriceForRent { get; set; }
    public int FlatId { get; set; }
    public int RoomId { get; set; }

    // Renter
    public string RenterUsername { get; set; }
    public string? RenterEmail { get; set; }
    public string RenterPhone { get; set; }
    public DateTime? RenterBirthDate { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
}