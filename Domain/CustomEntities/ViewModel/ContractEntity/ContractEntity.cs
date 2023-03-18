namespace Domain.CustomEntities.ViewModel.ContractEntity;

public class ContractEntity
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
    public string PriceForRent { get; set; } = null!;
    public string PriceForWater { get; set; } = null!;
    public string PriceForElectricity { get; set; } = null!;
    public string PriceForService { get; set; } = null!;
    public int? BuildingId { get; set; }
    //public int FlatId { get; set; }
    public int? RoomId { get; set; }
    //public int RenterId { get; set; }
}