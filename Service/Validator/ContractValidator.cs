using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
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

    public async Task<ValidatorResult> ValidateParams(Contract? obj, int? contractId)
    {
        try
        {
            if (contractId != null)
                switch (obj?.ContractId)
                {
                    case not null when obj.ContractId != contractId:
                        ValidatorResult.Failures.Add("Contract id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Contract is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ContractCheck(obj.ContractId) == null)
                            ValidatorResult.Failures.Add("Contract provided does not exist");
                        break;
                }

            switch (obj?.ContractName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Contract name is required");
                    break;
                case not null when obj.ContractName.Length > 100:
                    ValidatorResult.Failures.Add("Contract name cannot exceed 100 characters");
                    break;
            }

            if (obj?.DateSigned == null)
                ValidatorResult.Failures.Add("Date signed is required");

            if (obj?.StartDate == null)
                ValidatorResult.Failures.Add("Start date is required");

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Contract description is required");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Contract description cannot exceed 500 characters");
                    break;
            }

            if (obj?.EndDate == null)
                ValidatorResult.Failures.Add("End date is required");

            if (obj?.ContractStatus == null)
                ValidatorResult.Failures.Add("Contract status is required");

            switch (obj?.PriceForRent)
            {
                case not null when obj.PriceForRent <= 0:
                    ValidatorResult.Failures.Add("Rent price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Rent price is required");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case not null when obj.PriceForElectricity <= 0:
                    ValidatorResult.Failures.Add("Electricity price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Electricity price is required");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case not null when obj.PriceForWater <= 0:
                    ValidatorResult.Failures.Add("Water price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Water price is required");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case not null when obj.PriceForService <= 0:
                    ValidatorResult.Failures.Add("Service price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Service price is required");
                    break;
            }

            if (contractId == null)
                switch (obj?.RenterId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Renter is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                            ValidatorResult.Failures.Add("Renter provided does not exist");
                        break;
                }

            if (contractId == null)
                switch (obj?.BuildingId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null)
                            ValidatorResult.Failures.Add("Building provided does not exist");
                        break;
                }

            if (contractId == null)
                switch (obj?.FlatId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                            ValidatorResult.Failures.Add("Flat provided does not exist");
                        break;
                }

            if (contractId == null)
                switch (obj?.RoomId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Room is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RoomCheck(obj.RoomId) == null)
                            ValidatorResult.Failures.Add("Room provided does not exist");
                        break;
                }
            // TODO : Flat and Room check validation
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the contract");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(ContractUpdateRequest? obj, int? contractId)
    {
        try
        {
            if (contractId != null)
                switch (contractId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Hợp đồng là bắt buộc");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ContractCheck(contractId) == null)
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

    public async Task<ValidatorResult> ValidateParams(ContractCreateRequest? obj)
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
                case not null when await _conditionCheckHelper.EmployeeEmailCheck(obj.RenterEmail) != null:
                    ValidatorResult.Failures.Add("Địa chỉ email đã được sử dụng");
                    break;
                case not null when await _conditionCheckHelper.RenterEmailCheck(obj.RenterEmail) != null:
                    ValidatorResult.Failures.Add("Địa chỉ email đã được sử dụng");
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
                case not null when obj.RenterBirthDate > DateTime.Now:
                    ValidatorResult.Failures.Add("Ngày sinh không được lớn hơn ngày hiện tại");
                    break;
                case not null when DateTime.Now.Date.Year - obj.RenterBirthDate.Value.Date.Year < 18:
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
                case not null when await _conditionCheckHelper.FlatCheck(obj.FlatId) == null:
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
                case not null when await _conditionCheckHelper.RoomCheck(obj.RoomId) == null:
                    ValidatorResult.Failures.Add("Phòng không tồn tại");
                    break;
                case not null when await _conditionCheckHelper.RoomCheck(obj.RoomId) != null:
                    var room = await _conditionCheckHelper.RoomCheck(obj.RoomId);
                    switch (room)
                    {
                        case not null when room.FlatId != obj.FlatId:
                            ValidatorResult.Failures.Add("Phòng này không thuộc căn hộ");
                            break;
                        case { AvailableSlots: 0 }:
                            ValidatorResult.Failures.Add("Phòng đã đầy");
                            break;
                        case { AvailableSlots: < 0 }:
                            ValidatorResult.Failures.Add("Phòng lỗi số lượng slot, vui lòng liên hệ quản trị viên");
                            break;
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