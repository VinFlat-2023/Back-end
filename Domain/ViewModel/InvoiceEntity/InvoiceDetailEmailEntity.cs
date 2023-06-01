using System.ComponentModel;
using Domain.ViewModel.PlaceholderForFeeEntity;
using Domain.ViewModel.ServiceEntity;
using Utilities.Extensions;

namespace Domain.ViewModel.InvoiceEntity;

public class InvoiceDetailEmailEntity
{
    [DisplayName("Số thứ tự")] public int InvoiceDetailId { get; set; }

    [DisplayName("Số lượng")] public decimal Amount { get; set; }

    [DisplayName("Đơn giá")] public decimal Price { get; set; }

    [SkipProperty] [Browsable(false)] public int InvoiceId { get; set; }

    [SkipProperty] [Browsable(false)] public InvoiceRenterDetailEntity Invoice { get; set; }

    [SkipProperty] [Browsable(false)] public int? ServiceId { get; set; }

    public ServiceDetailEntity? Service { get; set; }

    [SkipProperty] [Browsable(false)] public int? PlaceholderForFeeId { get; set; }

    public PlaceholderForFeeDetailEntity? PlaceholderForFee { get; set; }
}