using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Contract
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContractId { get; set; }

    public string ContractName { get; set; } = null!;
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public string Description { get; set; } = null!;
    public DateTime? EndDate { get; set; }
    public DateTime? LastUpdated { get; set; }
    public string ContractStatus { get; set; } = null!;
    public string? ImageUrl { get; set; }

    [NotMapped] public IFormFile? Image { get; set; }
    public double Price { get; set; }
    public int RenterId { get; set; }
    public virtual Renter Renter { get; set; } = null!;
    public int FlatId { get; set; }
    public virtual Flat Flat { get; set; } = null!;
}