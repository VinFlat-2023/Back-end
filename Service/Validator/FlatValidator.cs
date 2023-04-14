using Domain.EntitiesForManagement;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class FlatValidator : BaseValidator, IFlatValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public FlatValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId)
    {
        try
        {
            if (flatId != null)
                switch (obj?.FlatId)
                {
                    case not null when obj.FlatId != flatId:
                        ValidatorResult.Failures.Add("Flat id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                            ValidatorResult.Failures.Add("Flat provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Flat name is required");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Flat name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Flat description is required");
                    break;
                case not null when obj.Description.Length > 100:
                    ValidatorResult.Failures.Add("Flat description cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Flat status is required");

            if (obj?.WaterMeterBefore == null)
                ValidatorResult.Failures.Add("Flat water meter is required");

            if (obj?.ElectricityMeterBefore == null)
                ValidatorResult.Failures.Add("Flat electricity meter is required");

            if (obj?.WaterMeterAfter == null)
                ValidatorResult.Failures.Add("Flat water meter is required");

            if (obj?.ElectricityMeterAfter == null)
                ValidatorResult.Failures.Add("Flat electricity meter is required");

            if (flatId == null)
                switch (obj?.FlatTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Flat type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId) == null)
                            ValidatorResult.Failures.Add("Flat type provided does not exist");
                        break;
                }

            if (flatId == null)
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
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the area");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatUpdateRequest? obj, int? flatId)
    {
        try
        {
            if (flatId != null)
                switch (flatId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Căn hộ là bắt buộc");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(flatId) == null)
                            ValidatorResult.Failures.Add("Căn hộ không tồn tại");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên căn hộ là bắt buộc");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Tên căn hộ không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Chi tiết là bắt buộc");
                    break;
                case not null when obj.Description.Length > 100:
                    ValidatorResult.Failures.Add("Chi tiết không được vượt quá 100 ký tự");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái là bắt buộc");

            if (obj?.WaterMeterBefore == null)
                ValidatorResult.Failures.Add("Chỉ số nước trước là bắt buộc");

            if (obj?.ElectricityMeterBefore == null)
                ValidatorResult.Failures.Add("Chỉ số điện trước là bắt buộc");

            if (obj?.WaterMeterAfter == null)
                ValidatorResult.Failures.Add("Chỉ số nước sau là bắt buộc");

            if (obj?.ElectricityMeterAfter == null)
                ValidatorResult.Failures.Add("Chỉ số điện sau là bắt buộc");

            if (flatId == null)
                switch (obj?.FlatTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Loại căn hộ là bắt buộc");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId) == null)
                            ValidatorResult.Failures.Add("Loại căn hộ không tồn tại");
                        break;
                }

            if (flatId == null)
                switch (obj?.BuildingId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Toà nhà là bắt buộc");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null)
                            ValidatorResult.Failures.Add("Toà nhà không tồn tại");
                        break;
                }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực căn hộ");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatCreateRequest? obj)
     {
        try
        {
            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên căn hộ là bắt buộc");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Tên căn hộ không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Chi tiết là bắt buộc");
                    break;
                case not null when obj.Description.Length > 100:
                    ValidatorResult.Failures.Add("Chi tiết không được vượt quá 100 ký tự");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái là bắt buộc");

            switch (obj?.FlatTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại căn hộ");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId) == null)
                        ValidatorResult.Failures.Add("Loại căn hộ không tồn tại");
                    break;
            }

            switch (obj?.BuildingId)
            {
                case null:
                    ValidatorResult.Failures.Add("Toà nhà là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null)
                        ValidatorResult.Failures.Add("Toà nhà không tồn tại");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực căn hộ");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId)
    {
        try
        {
            if (flatTypeId != null)
                switch (obj?.FlatTypeId)
                {
                    case not null when obj?.FlatTypeId != flatTypeId:
                        ValidatorResult.Failures.Add("Flat type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId) == null)
                            ValidatorResult.Failures.Add("Flat type provided does not exist");
                        break;
                }


            switch (obj?.RoomCapacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Flat type capacity is required");
                    break;
                case not null when obj.RoomCapacity < 1:
                    ValidatorResult.Failures.Add("Flat type capacity must be greater than 0");
                    break;
                case not null when obj.RoomCapacity > 20:
                    ValidatorResult.Failures.Add("Flat type capacity must be less than 20");
                    break;
            }

            if (flatTypeId == null)
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

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Flat type status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the flat");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatTypeUpdateRequest? obj, int? flatTypeId)
    {
        try
        {
            if (flatTypeId != null)
                switch (flatTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Loại căn hộ là bắt buộc");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(flatTypeId) == null)
                            ValidatorResult.Failures.Add("Loại căn hộ không tồn tại");
                        break;
                }


            switch (obj?.RoomCapacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại căn hộ là bắt buộc");
                    break;
                case not null when obj.RoomCapacity < 1:
                    ValidatorResult.Failures.Add("Số lượng phòng phải lớn hơn 0");
                    break;
                case not null when obj.RoomCapacity > 20:
                    ValidatorResult.Failures.Add("Số lượng phòng phải nhỏ hơn 20");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái là bắt buộc");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực loại căn hộ");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatTypeCreateRequest? obj)
    {
        try
        {
            switch (obj?.RoomCapacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại căn hộ là bắt buộc");
                    break;
                case not null when obj.RoomCapacity < 1:
                    ValidatorResult.Failures.Add("Số lượng phòng phải lớn hơn 0");
                    break;
                case not null when obj.RoomCapacity > 20:
                    ValidatorResult.Failures.Add("Số lượng phòng phải nhỏ hơn 20");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái là bắt buộc");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("Có lỗi xảy ra khi xác thực loại căn hộ");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }
}