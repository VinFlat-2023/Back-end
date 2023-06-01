using System.ComponentModel;

namespace Domain.ViewModel.RenterEntity;

public class RenterEmailDetailEntity
{
    [DisplayName("Họ và tên")] public string Fullname { get; set; }

    [DisplayName("Số điện thoại")] public string PhoneNumber { get; set; }

    [DisplayName("Địa chỉ email")] public string Email { get; set; }

    [DisplayName("Tên căn hộ")] public string FlatName { get; set; }

    [DisplayName("Tổng tiền")] public decimal TotalAmount { get; set; }
}