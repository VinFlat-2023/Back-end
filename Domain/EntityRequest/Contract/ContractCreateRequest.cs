using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Contract;

public class ContractCreateRequest
{
    public DateTime DateSigned { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [MaxLength(200, ErrorMessage = "Description length must less than 200")]
    public string Description { get; set; } = null!;

    [DataType(DataType.ImageUrl)] public string? ImageUrl { get; set; }

    [NotMapped] public IFormFile? Image { get; set; }

    [MaxLength(20, ErrorMessage = "Status length must less than 20")]
    public string? ContractStatus { get; set; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Price must not be negative")]
    public double Price { get; set; }

    public int RenterId { get; set; } // User Id
}