using Domain.EntityRequest.RoomType;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class RoomTypeValidator : BaseValidator, IRoomTypeValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public RoomTypeValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(RoomTypeUpdateRequest? obj, int? roomId, int? buildingId,
        CancellationToken token)
    {
        try
        {
            if (obj is null)
                ValidatorResult.Failures.Add("Thông tin phòng không được để trống");

            switch (roomId)
            {
                case null:
                    ValidatorResult.Failures.Add("Mã phòng không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RoomCheck(roomId, buildingId, token) == null)
                        ValidatorResult.Failures.Add("Phòng không tồn tại");
                    break;
            }

            switch (buildingId)
            {
                case null:
                    ValidatorResult.Failures.Add("Mã tòa nhà không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.BuildingCheck(buildingId, token) == null)
                        ValidatorResult.Failures.Add("Tòa nhà không tồn tại");
                    break;
            }

            switch (obj?.Status)
            {
                case null:
                    ValidatorResult.Failures.Add("Trạng thái không được để trống");
                    break;
            }

            switch (obj?.RoomTypeName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên phòng không được để trống");
                    break;
                case not null when obj.RoomTypeName.Length > 500:
                    ValidatorResult.Failures.Add("Tên phòng không được quá 500 ký tự");
                    break;
            }

            switch (obj?.TotalSlot)
            {
                case null:
                    ValidatorResult.Failures.Add("Số lượng chỗ không được để trống");
                    break;
                case not null:
                    var roomCheck = await _conditionCheckHelper.RoomCheck(roomId, buildingId, token);
                    switch (roomCheck)
                    {
                        case null:
                            ValidatorResult.Failures.Add("Phòng không tồn tại");
                            break;
                        case not null:
                            // Check if anyone rented this room
                            var isAnyoneRentedCheckCheck =
                                await _conditionCheckHelper.IsAnyoneRentedCheck(roomId, buildingId, token);
                            switch (isAnyoneRentedCheckCheck.IsSuccess)
                            {
                                case true:
                                    break;
                                case false:
                                    ValidatorResult.Failures.Add(isAnyoneRentedCheckCheck.Message);
                                    break;
                            }

                            break;
                    }

                    if (obj.TotalSlot <= 0)
                        ValidatorResult.Failures.Add("Số lượng chỗ phải lớn hơn 0");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the room");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(RoomTypeCreateRequest? obj, int? buildingId,
        CancellationToken token)
    {
        try
        {
            if (obj is null)
                ValidatorResult.Failures.Add("Thông tin phòng không được để trống");

            switch (buildingId)
            {
                case null:
                    ValidatorResult.Failures.Add("Mã tòa nhà không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.BuildingCheck(buildingId, token) == null)
                        ValidatorResult.Failures.Add("Tòa nhà không tồn tại");
                    break;
            }

            switch (obj?.RoomTypeName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên phòng không được để trống");
                    break;
                case not null when obj.RoomTypeName.Length > 500:
                    ValidatorResult.Failures.Add("Tên phòng không được quá 500 ký tự");
                    break;
            }

            switch (obj?.TotalSlot)
            {
                case null:
                    ValidatorResult.Failures.Add("Số lượng chỗ không được để trống");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the room");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}