using System.Text.Json.Serialization;
using Domain.EntitiesDTO.FlatDTO;
using Domain.EntitiesDTO.RenterDTO;
using Domain.EntitiesDTO.TicketDTO;

namespace Domain.EntitiesDTO.ContractDTO;

public class ContractDto
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

    //[NotMapped] public IFormFile? Image { get; set; }
    public decimal PriceForRent { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
    public int? BuildingId { get; set; }
    public int? RoomId { get; set; }
    public int RenterId { get; set; }
    public virtual RenterDto Renter { get; set; } = null!;
    public int FlatId { get; set; }
    [JsonIgnore] public virtual FlatDto Flat { get; set; } = null!;
    [JsonIgnore] public virtual ICollection<TicketDto> Tickets { get; set; }
}