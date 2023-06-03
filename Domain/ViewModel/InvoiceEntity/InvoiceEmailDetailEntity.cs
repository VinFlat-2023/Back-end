using System.ComponentModel;
using Utilities.Extensions;

namespace Domain.ViewModel.InvoiceEntity;

public class InvoiceEmailDetailEntity
{
    [DisplayName("Tên hoá đơn")] public string Name { get; set; }

    [DisplayName("Thông tin chi tiết")] public string Detail { get; set; }

    [DisplayName("Tổng tiền")] public decimal TotalAmount { get; set; }

    [DisplayName("Ngày tạo")] public DateTime CreatedTime { get; set; }

    [DisplayName("Ngày hết hạn")] public DateTime? DueDate { get; set; }
    [SkipProperty] [Browsable(false)] public DateTime? PaymentTime { get; set; }

    [DisplayName("Ngày thanh toán")]
    public string PaymentTimeStr => PaymentTime?.ToString("dd/MM/yyyy HH:mm:ss") ?? "Chưa thanh toán";

    [SkipProperty] [Browsable(false)] public bool Status { get; set; }

    [DisplayName("Trạng thái thanh toán")] public string StatusStr => Status ? "Đã thanh toán" : "Chưa thanh toán";

    [SkipProperty] [Browsable(false)] public virtual ICollection<InvoiceDataDetailEntity> InvoiceDetails { get; set; }
}