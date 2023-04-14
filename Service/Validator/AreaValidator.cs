using Domain.EntitiesForManagement;
using Domain.EntityRequest.Area;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class AreaValidator : BaseValidator, IAreaValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public AreaValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Area? obj, int? areaId)
    {
        try
        {
            if (areaId != null)
                switch (obj?.AreaId)
                {
                    case not null when obj.AreaId != areaId:
                        ValidatorResult.Failures.Add("Khu vực không hợp lệ");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Khu vực không được để trống");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.AreaCheck(obj.AreaId) == null)
                            ValidatorResult.Failures.Add("Khu vực không tồn tại");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Tên khu vực không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên khu vực không được để trống");
                    break;
            }

            switch (obj?.Location)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Location):
                    ValidatorResult.Failures.Add("Địa chỉ không được để trống");
                    break;
                case not null when obj.Location.Length > 100:
                    ValidatorResult.Failures.Add("Địa chỉ không được vượt quá 100 ký tự");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái khu vực không được để trống");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực thông tin khu vực");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(AreaUpdateRequest? obj, int? areaId)
    {
        try
        {
            if (areaId != null)
                switch (areaId)
                {
                    case not null:
                        if (await _conditionCheckHelper.AreaCheck(areaId) == null)
                            ValidatorResult.Failures.Add("Khu vực không tồn tại");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Khu vực không được để trống");
                        break;
                }

            switch (obj?.Name)
            {
                case { Length: > 100 }:
                    ValidatorResult.Failures.Add("Tên khu vực không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên khu vực không được để trống");
                    break;
            }

            switch (obj?.Location)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Location):
                    ValidatorResult.Failures.Add("Địa chỉ không được để trống");
                    break;
                case { Length: > 100 }:
                    ValidatorResult.Failures.Add("Địa chỉ không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Status)
            {
                case null:
                    ValidatorResult.Failures.Add("Trạng thái khu vực không được để trống");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực khu vực");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(AreaCreateRequest? obj)
    {
        try
        {
            switch (obj?.Name)
            {
                case { Length: > 100 }:
                    ValidatorResult.Failures.Add("Tên khu vực không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên khu vực không được để trống");
                    break;
            }

            switch (obj?.Location)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Location):
                    ValidatorResult.Failures.Add("Địa chỉ không được để trống");
                    break;
                case { Length: > 100 }:
                    ValidatorResult.Failures.Add("Địa chỉ không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Status)
            {
                case null:
                    ValidatorResult.Failures.Add("Trạng thái khu vực không được để trống");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực khu vực");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }
}