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

    public async Task<ValidatorResult> ValidateParams(RoomUpdateRequest? obj, int building, int? roomId,
        CancellationToken token)
    {
        try
        {
            if (obj is null)
                ValidatorResult.Failures.Add("Thông tin phòng không được để trống");

            switch (obj?.FlatId)
            {
                case null:
                    ValidatorResult.Failures.Add("Mã phòng không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FlatCheck(obj.FlatId, building, token) == null)
                        ValidatorResult.Failures.Add("Phòng không tồn tại");
                    break;
            }

            if (await _conditionCheckHelper.GetRoomInAFlatById(roomId, obj.FlatId, building, token) == null)
                ValidatorResult.Failures.Add("Phòng không tồn tại");

            switch (obj?.RoomTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Mã loại phòng không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RoomTypeCheck(obj.RoomTypeId, building, token) == null)
                        ValidatorResult.Failures.Add("Loại phòng không tồn tại");
                    break;
            }

            switch (obj?.RoomName)
            {
                case null:
                    ValidatorResult.Failures.Add("Tên phòng không được để trống");
                    break;
                case not null:
                    switch (obj.RoomName.Length)
                    {
                        case > 100:
                            ValidatorResult.Failures.Add("Tên phòng không được vượt quá 100 ký tự");
                            break;
                        case < 4:
                            ValidatorResult.Failures.Add("Tên phòng không được ít hơn 4 ký tự");
                            break;
                    }

                    break;
            }

            switch (obj?.ElectricityAttribute)
            {
                case null:
                    ValidatorResult.Failures.Add("Chỉ số điện không được để trống");
                    break;
                case not null:
                    if (obj.ElectricityAttribute < 0)
                        ValidatorResult.Failures.Add("Chỉ số điện không được nhỏ hơn 0");
                    break;
            }

            switch (obj?.WaterAttribute)
            {
                case null:
                    ValidatorResult.Failures.Add("Chỉ số nước không được để trống");
                    break;
                case not null:
                    if (obj.WaterAttribute < 0)
                        ValidatorResult.Failures.Add("Chỉ số nước không được nhỏ hơn 0");
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
            ValidatorResult.Failures.Add("An error occurred while validating the service");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}