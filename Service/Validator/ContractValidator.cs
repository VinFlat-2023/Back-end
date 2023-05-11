using System.Text.RegularExpressions;
using Domain.EntityRequest.Contract;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class ContractValidator : BaseValidator, IContractValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public ContractValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }


    public async Task<ValidatorResult> ValidateParams(ContractUpdateRequest? obj, int? contractId,
        CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Thông tin hợp đồng là bắt buộc");

            switch (contractId)
            {
                case null:
                    ValidatorResult.Failures.Add("Hợp đồng không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.ContractCheck(contractId, token) == null)
                        ValidatorResult.Failures.Add("Hợp đồng không tồn tại");
                    break;
            }

            switch (obj?.ContractName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Tên hợp đồng là bắt buộc");
                    break;
                case not null when obj.ContractName.Length > 100:
                    ValidatorResult.Failures.Add("Tên hợp đồng không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.DateSigned)
            {
                case null:
                    ValidatorResult.Failures.Add("Ngày ký hợp đồng là bắt buộc");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Mô tả là bắt buộc");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Mô tả không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.StartDate)
            {
                case null:
                    ValidatorResult.Failures.Add("Ngày bắt đầu là bắt buộc");
                    break;
            }

            switch (obj?.EndDate)
            {
                case not null when obj.EndDate > DateTime.Now:
                    ValidatorResult.Failures.Add("Ngày kết thúc không được nhỏ hơn ngày hiện tại");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Ngày kết thúc hợp đồng là bắt buộc");
                    break;
            }

            switch (obj?.ContractStatus)
            {
                case not null when string.IsNullOrWhiteSpace(obj.ContractStatus):
                    ValidatorResult.Failures.Add("Trạng thái hợp đồng là bắt buộc");
                    break;
                case not null when obj.ContractStatus.ToLower() != "active"
                                   || obj.ContractStatus.ToLower() != "inactive"
                                   || obj.ContractStatus.ToLower() != "suspend":
                    ValidatorResult.Failures.Add(
                        "Trạng thái hợp đồng phải là 'Đang hoạt động', 'Hết hạn' hoặc 'Tạm dừng'");
                    break;
            }

            switch (obj?.PriceForRent)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForRent):
                    ValidatorResult.Failures.Add("Tiền thuê nhà không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForRent) < 0:
                    ValidatorResult.Failures.Add("Tiền thuê nhà không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForRent) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền thuê nhà không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForElectricity):
                    ValidatorResult.Failures.Add("Tiền điện mỗi số không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForElectricity) < 0:
                    ValidatorResult.Failures.Add("Tiền điện mỗi số không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForElectricity) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền điện mỗi số không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForWater):
                    ValidatorResult.Failures.Add("Tiền nước mỗi khối không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForWater) < 0:
                    ValidatorResult.Failures.Add("Tiền nước mỗi khối không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForWater) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền nước mỗi khối không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForService):
                    ValidatorResult.Failures.Add("Tiền dịch vụ toà nhà không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForService) < 0:
                    ValidatorResult.Failures.Add("Tiền dịch vụ toà nhà không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForService) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền dịch vụ toà nhà không được lớn hơn 1,000,000,000");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực thông tin hợp đồng");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }

    public async Task<ValidatorResult> ValidateParams(ContractCreateRequest? obj, int buildingId,
        CancellationToken token)
    {
        try
        {
            switch (obj?.RenterUsername)
            {
                case not null when string.IsNullOrWhiteSpace(obj.RenterUsername):
                    ValidatorResult.Failures.Add("Tên tai khoản là bắt buộc");
                    break;
                case not null when obj.RenterUsername.Length > 100:
                    ValidatorResult.Failures.Add("Tên tai khoản không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.FullName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.FullName):
                    ValidatorResult.Failures.Add("Tên người thuê là bắt buộc");
                    break;
                case not null when obj.FullName.Length > 100:
                    ValidatorResult.Failures.Add("Tên người thuê không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.RenterEmail)
            {
                case not null when obj.RenterEmail.Length > 100:
                    ValidatorResult.Failures.Add("Địa chỉ email không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.RenterEmail):
                    ValidatorResult.Failures.Add("Địa chỉ email là bắt buộc");
                    break;
                case not null when !Regex.IsMatch(obj.RenterEmail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Địa chỉ email không hợp lệ");
                    break;
                case not null:
                    var employee = await _conditionCheckHelper.EmployeeEmailCheck(obj.RenterEmail, token);
                    switch (employee.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(employee.Message);
                            break;
                    }

                    var renter = await _conditionCheckHelper.RenterEmailCheck(obj.RenterEmail, token);
                    switch (renter.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(renter.Message);
                            break;
                    }

                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.RenterPhone)
            {
                case not null when string.IsNullOrWhiteSpace(obj.RenterPhone):
                    ValidatorResult.Failures.Add("Điện thoại không được để trống");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.RenterPhone):
                    ValidatorResult.Failures.Add("Điện thoại không hợp lệ");
                    break;
                case not null when obj.RenterPhone.Length > 13:
                    ValidatorResult.Failures.Add("Số điện thoại không được quá 13 số");
                    break;
                case not null when obj.RenterPhone.Length < 7:
                    ValidatorResult.Failures.Add("Số điện thoại không được ít hơn 7 số");
                    break;
            }

            switch (obj?.RenterBirthDate)
            {
                case not null when DateTime.ParseExact(obj.RenterBirthDate, "dd/MM/yyyy", null) > DateTime.Now:
                    ValidatorResult.Failures.Add("Ngày sinh không được lớn hơn ngày hiện tại");
                    break;
                case not null when DateTime.Now.Date.Year -
                    DateTime.ParseExact(obj.RenterBirthDate, "dd/MM/yyyy", null).Date.Year < 18:
                    ValidatorResult.Failures.Add("Người thuê phải trên 18 tuổi");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Ngày sinh không được để trống");
                    break;
            }

            switch (obj?.Address)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("Địa chỉ không được để trống");
                    break;
            }

            switch (obj?.ContractName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Tên hợp đồng không được để trống");
                    break;
                case not null when obj.ContractName.Length > 100:
                    ValidatorResult.Failures.Add("Tên hợp đồng không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.DateSigned)
            {
                case null:
                    ValidatorResult.Failures.Add("Ngày ký hợp đồng không được để trống");
                    break;
            }

            switch (obj?.StartDate)
            {
                case null:
                    ValidatorResult.Failures.Add("Ngày bắt đầu không được để trống");
                    break;
            }

            switch (obj?.EndDate)
            {
                case not null when obj.EndDate < DateTime.Now:
                    ValidatorResult.Failures.Add("Ngày kết thúc hợp đồng phải lớn hơn ngày hiện tại");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Ngày kết thúc hợp đồng không được để trống");
                    break;
            }

            switch (obj?.ContractStatus)
            {
                case not null when string.IsNullOrWhiteSpace(obj.ContractStatus):
                    ValidatorResult.Failures.Add("Trạng thái hợp đồng không được để trống");
                    break;
                case not null when obj.ContractStatus.ToLower() != "active"
                                   || obj.ContractStatus.ToLower() != "inactive"
                                   || obj.ContractStatus.ToLower() != "suspend":
                    ValidatorResult.Failures.Add(
                        "Trạng thái hợp đồng phải là 'Đang hoạt động', 'Hết hạn' hoặc 'Tạm dừng'");
                    break;
            }

            switch (obj?.PriceForRent)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForRent):
                    ValidatorResult.Failures.Add("Tiền thuê nhà không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForRent) < 0:
                    ValidatorResult.Failures.Add("Tiền thuê nhà không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForRent) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền thuê nhà không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForElectricity):
                    ValidatorResult.Failures.Add("Tiền điện mỗi số không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForElectricity) < 0:
                    ValidatorResult.Failures.Add("Tiền điện mỗi số không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForElectricity) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền điện mỗi số không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForWater):
                    ValidatorResult.Failures.Add("Tiền nước mỗi khối không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForWater) < 0:
                    ValidatorResult.Failures.Add("Tiền nước mỗi khối không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForWater) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền nước mỗi khối không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case not null when string.IsNullOrWhiteSpace(obj.PriceForService):
                    ValidatorResult.Failures.Add("Tiền dịch vụ toà nhà không được để trống");
                    break;
                case not null when decimal.Parse(obj.PriceForService) < 0:
                    ValidatorResult.Failures.Add("Tiền dịch vụ toà nhà không được nhỏ hơn 0");
                    break;
                case not null when decimal.Parse(obj.PriceForService) > 1000000000:
                    ValidatorResult.Failures.Add("Tiền dịch vụ toà nhà không được lớn hơn 1,000,000,000");
                    break;
            }

            switch (obj?.FlatId)
            {
                case null:
                    ValidatorResult.Failures.Add("Căn hộ là không được để trống");
                    break;
                case not null when obj.FlatId < 0:
                    ValidatorResult.Failures.Add("Căn hộ không hợp lệ");
                    break;
                case not null when await _conditionCheckHelper.FlatCheck(obj.FlatId, buildingId, token) == null:
                    ValidatorResult.Failures.Add("Căn hộ không tồn tại");
                    break;
            }

            switch (obj?.RoomId)
            {
                case null:
                    ValidatorResult.Failures.Add("Phòng là bắt buộc");
                    break;
                case not null when obj.RoomId < 0:
                    ValidatorResult.Failures.Add("Phòng không hợp lệ");
                    break;
                case not null when await _conditionCheckHelper.RoomCheck(obj.RoomId, buildingId, token) == null:
                    ValidatorResult.Failures.Add("Phòng không tồn tại");
                    break;
                case not null:
                    var room = await _conditionCheckHelper.RoomCheck(obj.RoomId, buildingId, token);
                    switch (room)
                    {
                        /*
                        case not null when room.FlatId != obj.FlatId:
                            ValidatorResult.Failures.Add("Phòng này không thuộc căn hộ");
                            break;
                        case { AvailableSlots: 0 }:
                            ValidatorResult.Failures.Add("Phòng đã đầy");
                            break;
                        case { AvailableSlots: < 0 }:
                            ValidatorResult.Failures.Add("Phòng lỗi số lượng slot, vui lòng liên hệ quản trị viên");
                            break;
                                                    */
                    }

                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực hợp đông");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }
}