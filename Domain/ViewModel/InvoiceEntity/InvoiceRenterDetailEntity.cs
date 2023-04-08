using Domain.ViewModel.EmployeeEntity;
using Domain.ViewModel.InvoiceTypeEntity;
using Domain.ViewModel.RenterEntity;

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
    public DateTime? PaymentTime { get; set; }
    public DateTime CreatedTime { get; set; }
    public int? RenterId { get; set; }
    public RenterBasicDetailEntity? Renter { get; set; }
    public int EmployeeId { get; set; }
    public EmployeeBasicDetailEntity Employee { get; set; }
    public int InvoiceTypeId { get; set; }
    public InvoiceTypeDetailEntity InvoiceType { get; set; }
    public ICollection<InvoiceDataDetailEntity> InvoiceDetails { get; set; }
}