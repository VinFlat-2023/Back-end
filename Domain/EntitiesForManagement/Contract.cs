using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntitiesForManagement;

public class Contract
{
    public Contract()
    {
        ContractHistories = new HashSet<ContractHistory>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ContractId { get; set; }

    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? LastUpdated { get; set; }
    public string ContractStatus { get; set; }
    public string? ImageUrl { get; set; }

    [NotMapped] public IFormFile? Image { get; set; }
    public double Price { get; set; }
    public virtual ICollection<ContractHistory> ContractHistories { get; set; }
}