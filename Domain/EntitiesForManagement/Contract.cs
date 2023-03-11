using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Contract
{
    public Contract()
    {
        Tickets = new HashSet<Ticket>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContractId { get; set; }

    public string ContractName { get; set; } = null!;
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public string? ImageUrl { get; set; }
    [NotMapped] public IFormFile? Image { get; set; }
    public decimal PriceForRent { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
    public int? BuildingId { get; set; }
    public int? RoomId { get; set; }
    public int RenterId { get; set; }
    public virtual Renter Renter { get; set; } = null!;
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; } = null!;
    public virtual ICollection<Ticket> Tickets { get; set; }
}