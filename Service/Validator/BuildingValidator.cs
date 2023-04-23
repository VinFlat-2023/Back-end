using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Building;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class BuildingValidator : BaseValidator, IBuildingValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public BuildingValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(BuildingUpdateRequest? obj, int? buildingId,
        CancellationToken token)
    {
        try
        {
            if (buildingId != null)
                switch (buildingId)
                {
                    case not null when await _conditionCheckHelper.BuildingCheck(buildingId, token) == null:
                        ValidatorResult.Failures.Add("Toà nhà không tồn tại");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Toà nhà không được để trống");
                        break;
                }

            switch (obj?.BuildingName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingName):
                    ValidatorResult.Failures.Add("Tên toà nhà không được để trống");
                    break;
                case not null when obj.BuildingName.Length > 100:
                    ValidatorResult.Failures.Add("Tên toà nhà không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Chi tiết không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Chi tiết không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.BuildingAddress)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingAddress):
                    ValidatorResult.Failures.Add("Địa chỉ không được để trống");
                    break;

                case not null when obj.BuildingAddress.Length > 500:
                    ValidatorResult.Failures.Add("Địa chỉ không được vượt quá 500 ký tự");
                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.BuildingPhoneNumber)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Số điện thoại không được để trống");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Số điện thoại không hợp lệ");
                    break;
            }

            switch (obj?.AveragePrice)
            {
                case not null when obj.AveragePrice < 0:
                    ValidatorResult.Failures.Add("Giá tiền không được nhỏ hơn 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Giá tiền không được để trống");
                    break;
            }

            switch (obj?.AreaId)
            {
                case null:
                    ValidatorResult.Failures.Add("Khu vực không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.AreaCheck(obj.AreaId, token) == null)
                        ValidatorResult.Failures.Add("Khu vực không tồn tại");
                    break;
            }

            switch (obj?.Status)
            {
                case null:
                    ValidatorResult.Failures.Add("Trạng thái không được để trống");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực thông tin toà nhà");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(BuildingCreateRequest? obj, CancellationToken token)
    {
        try
        {
            switch (obj?.BuildingName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingName):
                    ValidatorResult.Failures.Add("Tên toà nhà không được để trống");
                    break;
                case not null when obj.BuildingName.Length > 100:
                    ValidatorResult.Failures.Add("Tên toà nhà không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Chi tiết không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Chi tiết không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.BuildingAddress)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingAddress):
                    ValidatorResult.Failures.Add("Địa chỉ không được để trống");
                    break;

                case not null when obj.BuildingAddress.Length > 500:
                    ValidatorResult.Failures.Add("Địa chỉ không được vượt quá 500 ký tự");
                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.BuildingPhoneNumber)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Số điện thoại không được để trống");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Số điện thoại không hợp lệ");
                    break;
            }

            switch (obj?.AveragePrice)
            {
                case not null when obj.AveragePrice < 0:
                    ValidatorResult.Failures.Add("Giá tiền không được nhỏ hơn 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Giá tiền không được để trống");
                    break;
            }

            switch (obj?.AreaId)
            {
                case null:
                    ValidatorResult.Failures.Add("Khu vực không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.AreaCheck(obj.AreaId, token) == null)
                        ValidatorResult.Failures.Add("Khu vực không tồn tại");
                    break;
            }

            switch (obj?.Status)
            {
                case null:
                    ValidatorResult.Failures.Add("Trạng thái không được để trống");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực thông tin toà nhà");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(Building? obj, int? buildingId, CancellationToken token)
    {
        try
        {
            if (buildingId != null)
                switch (obj?.BuildingId)
                {
                    case not null when obj.BuildingId != buildingId:
                        ValidatorResult.Failures.Add("Toà nhà không hợp lệ");
                        break;
                    case not null when await _conditionCheckHelper.BuildingCheck(obj.BuildingId, token) == null:
                        ValidatorResult.Failures.Add("Toà nhà không tồn tại");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Toà nhà không được để trống");
                        break;
                }

            switch (obj?.BuildingName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingName):
                    ValidatorResult.Failures.Add("Tên toà nhà không được để trống");
                    break;
                case not null when obj.BuildingName.Length > 100:
                    ValidatorResult.Failures.Add("Tên toà nhà không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Chi tiết toà nhà không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Chi tiết toà nhà không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.BuildingAddress)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingAddress):
                    ValidatorResult.Failures.Add("Địa chỉ toà nhà không được để trống");
                    break;
                case not null when obj.BuildingAddress.Length > 500:
                    ValidatorResult.Failures.Add("Địa chỉ toà nhà không được vượt quá 500 ký tự");
                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.BuildingPhoneNumber)
            {
                case not null when string.IsNullOrWhiteSpace(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Số điện thoại toà nhà không được để trống");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Số điện thoại toà nhà không hợp lệ");
                    break;
            }

            switch (obj?.AveragePrice)
            {
                case not null when obj.AveragePrice < 0:
                    ValidatorResult.Failures.Add("Giá tiền trung bình không được nhỏ hơn 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Giá tiền trung bình không được để trống");
                    break;
            }

            switch (obj?.AreaId)
            {
                case null:
                    ValidatorResult.Failures.Add("Khu vực không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.AreaCheck(obj.AreaId, token) == null)
                        ValidatorResult.Failures.Add("Khu vực không tồn tại");
                    break;
            }

            if (buildingId == null)
                switch (obj?.EmployeeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Quản lý toà nhà không được để trống");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId, token) == null)
                            ValidatorResult.Failures.Add("Quản lý toà nhà không tồn tại");
                        break;
                }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái toà nhà không được để trống");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực thông tin toà nhà");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}