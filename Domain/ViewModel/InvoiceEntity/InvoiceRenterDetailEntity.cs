using Domain.EntitiesForManagement;
using Domain.ViewModel.InvoiceDetailEntity;
using Microsoft.AspNetCore.Http;

namespace Domain.ViewModel.InvoiceEntity;

public class InvoiceRenterDetailEntity
{
    public int InvoiceId { get; set; }
    public string Name { get; set; } = null!;
    public int Amount { get; set; }
    public bool Status { get; set; }
    public DateTime? DueDate { get; set; }
    public string? Detail { get; set; }
    public string? ImageUrl { get; set; }
    public IFormFile? Image { get; set; }
    public DateTime? PaymentTime { get; set; }
    public DateTime CreatedTime { get; set; }
    public int? RenterId { get; set; }
    public Renter? Renter { get; set; }
    public int AccountId { get; set; }
    public Account Account { get; set; }
    public int InvoiceTypeId { get; set; }
    public InvoiceType InvoiceType { get; set; }
    public ICollection<InvoiceDataDetailEntity> InvoiceDetails { get; set; }
}