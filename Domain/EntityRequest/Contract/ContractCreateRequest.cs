using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Domain.EntityRequest.Contract;

public class ContractCreateRequest
{
    public string? ContractName { get; set; }
    public string DateSigned { get; set; }
    public string StartDate { get; set; }
    public string? Description { get; set; }
    public string? EndDate { get; set; }
    public string? ContractStatus { get; set; }
    public decimal PriceForWater { get; set; }
    public decimal PriceForElectricity { get; set; }
    public decimal PriceForService { get; set; }
    public string? ImageUrl { get; set; }
    [NotMapped] public IFormFile? Image { get; set; }
    public decimal PriceForRent { get; set; }
    public int RenterId { get; set; }
    public int BuildingId { get; set; }
    public int FlatId { get; set; }
    public int RoomId { get; set; }
}