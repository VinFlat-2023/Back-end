using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class ContractHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContractHistoryId { get; set; }

    public double? Price { get; set; }
    public string Description { get; set; } = null!;
    public string? ContractHistoryStatus { get; set; }

    public string? ImageUrl { get; set; }

    [NotMapped] public IFormFile? Image { get; set; }
    public DateTime? ContractExpiredDate { get; set; }
    [ForeignKey("RenterId")] public int RenterId { get; set; }

    public virtual Renter Renter { get; set; } = null!;
    public int ContractId { get; set; } // Contract
    public virtual Contract Contract { get; set; } = null!;
}