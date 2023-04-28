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

    public async Task<ValidatorResult> ValidateParams(FlatTypeUpdateRequest? obj, int? flatTypeId,
        CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Thông tin loại phòng không được để trống");

            if (flatTypeId != null)
                switch (flatTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Mã loại phòng không được để trống");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(flatTypeId, token) == null)
                            ValidatorResult.Failures.Add("Mã loại phòng không tồn tại");
                        break;
                }

            switch (obj?.FlatTypeName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên loại phòng không được để trống");
                    break;
                case not null:
                    switch (obj.FlatTypeName)
                    {
                        case not null when obj.FlatTypeName.Length < 3:
                            ValidatorResult.Failures.Add("Tên loại phòng phải lớn hơn 3 ký tự");
                            break;

                        case not null when obj.FlatTypeName.Length > 50:
                            ValidatorResult.Failures.Add("Tên loại phòng phải nhỏ hơn 50 ký tự");
                            break;
                    }

                    break;
            }

            switch (obj?.RoomCapacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Tổng số phòng không được để trống");
                    break;
                case not null when obj.RoomCapacity < 1:
                    ValidatorResult.Failures.Add("Số phòng phải lớn hơn 0");
                    break;
                case not null when obj.RoomCapacity > 20:
                    ValidatorResult.Failures.Add("Số phòng phải nhỏ hơn 20");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái không được để trống");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the flat type");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatTypeCreateRequest? obj, CancellationToken flatId)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Thông tin loại căn hộ không được để trống");

            switch (obj?.FlatTypeName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên loại căn hộ không được để trống");
                    break;
                case not null:
                    switch (obj.FlatTypeName)
                    {
                        case not null when obj.FlatTypeName.Length < 3:
                            ValidatorResult.Failures.Add("Tên loại căn hộ phải lớn hơn 3 ký tự");
                            break;

                        case not null when obj.FlatTypeName.Length > 50:
                            ValidatorResult.Failures.Add("Tên loại căn hộ phải nhỏ hơn 50 ký tự");
                            break;
                    }

                    break;
            }

            switch (obj?.RoomCapacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Tổng số phòng không được để trống");
                    break;
                case not null when obj.RoomCapacity < 1:
                    ValidatorResult.Failures.Add("Số phòng phải lớn hơn 0");
                    break;
                case not null when obj.RoomCapacity > 20:
                    ValidatorResult.Failures.Add("Số phòng phải nhỏ hơn 20");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái không được để trống");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the flat type");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }

    public async Task<ValidatorResult> ValidateParams(FlatUpdateRequest? obj, int? flatId,
        CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Thông tin căm hộ không được để trống");
            if (flatId != null)
                switch (flatId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Căn hộ không được để trống");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(flatId, token) == null)
                            ValidatorResult.Failures.Add("Căn hộ không tồn tại");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên căn hộ không được để trống");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Tên căn hộ không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Mô tả chi tiết không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Thông tin mô tả không được vượt quá 500 ký tự");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái không được để trống");

            if (obj?.WaterMeterBefore == null)
                ValidatorResult.Failures.Add("Số nước trước không được để trống");

            if (obj?.ElectricityMeterBefore == null)
                ValidatorResult.Failures.Add("Số điện trước không được để trống");

            if (obj?.WaterMeterAfter == null)
                ValidatorResult.Failures.Add("Số nước sau không được để trống");

            if (obj?.ElectricityMeterAfter == null)
                ValidatorResult.Failures.Add("Số điện sau không được để trống");

            if (flatId == null)
                switch (obj?.FlatTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Loại căn hộ không được để trống");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId, token) == null)
                            ValidatorResult.Failures.Add("Loại căn hộ không tồn tại");
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

    public async Task<ValidatorResult> ValidateParams(FlatCreateRequest? obj, CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Thông tin căm hộ không được để trống");

            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Tên căn hộ không được để trống");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Tên căn hộ không được vượt quá 100 ký tự");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Mô tả chi tiết không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Thông tin mô tả không được vượt quá 500 ký tự");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Trạng thái không được để trống");

            switch (obj?.FlatTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại căn hộ không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId, token) == null)
                        ValidatorResult.Failures.Add("Loại căn hộ không tồn tại");
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

    public async Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId, CancellationToken token)
    {
        try
        {
            if (flatId != null)
                switch (obj?.FlatId)
                {
                    case not null when obj?.FlatId != flatId:
                        ValidatorResult.Failures.Add("Flat id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId, token) == null)
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
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId, token) == null)
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
                        if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId, token) == null)
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

    public async Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId, CancellationToken token)
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
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId, token) == null)
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
                        if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId, token) == null)
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
}