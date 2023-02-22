using Domain.EntitiesForManagement;
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

    public async Task<ValidatorResult> ValidateParams(Room? obj, int? roomId)
    {
        try
        {
            if (roomId != null)
                switch (obj?.RoomId)
                {
                    case { } when obj.RoomId != roomId:
                        ValidatorResult.Failures.Add("Room id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Room is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RoomCheck(obj.RoomId) == null)
                            ValidatorResult.Failures.Add("Room provided does not exist");
                        break;
                }

            if (obj is { AvailableSlots: <= 0 }) ValidatorResult.Failures.Add("This room is full");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the role");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}