using System.ComponentModel;

namespace Domain.ViewModel.InvoiceEntity;

public class InvoiceDetailEmailEntity
{
    [DisplayName("Tên dịch vụ")] public string Name { get; set; }

    [DisplayName("Số lượng")] public decimal Amount { get; set; }

    [DisplayName("Đơn giá (Đơn vị VNĐ)")] public decimal Price { get; set; }
}