using Domain.EntityRequest.Room;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class RoomValidator : BaseValidator, IRoomValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public RoomValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(RoomUpdateRequest? obj, int? roomId, int? buildingId,
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

            switch (obj?.Description)
            {
                case null:
                    ValidatorResult.Failures.Add("Mô tả không được để trống");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Mô tả không được quá 500 ký tự");
                    break;
            }

            switch (obj?.RoomSignName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên phòng không được để trống");
                    break;
                case { } when obj.RoomSignName.Length > 500:
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
                            var isAnyoneRentedCheckCheck =
                                await _conditionCheckHelper.IsAnyoneRentedCheck(roomId, buildingId, token);
                            switch (isAnyoneRentedCheckCheck.IsSuccess)
                            {
                                case true:
                                    break;
                                case false:
                                    ValidatorResult.Failures.Add(
                                        "Loại phòng đã có người thuê không thể thay đổi số lượng chỗ");
                                    break;
                            }

                            break;
                    }

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

    public async Task<ValidatorResult> ValidateParams(RoomCreateRequest? obj, int? buildingId, CancellationToken token)
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

            switch (obj?.Description)
            {
                case null:
                    ValidatorResult.Failures.Add("Mô tả không được để trống");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Mô tả không được quá 500 ký tự");
                    break;
            }

            switch (obj?.RoomSignName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên phòng không được để trống");
                    break;
                case { } when obj.RoomSignName.Length > 500:
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