using Domain.EntityRequest.Room;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class RoomFlatValidator : BaseValidator, IRoomFlatValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public RoomFlatValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public Task<ValidatorResult> ValidateParams(RoomCreateRequest? obj, int? roomId, int? buildingId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<ValidatorResult> ValidateParams(RoomUpdateRequest? obj, int? flatId, int? roomId, int? buildingId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }
}