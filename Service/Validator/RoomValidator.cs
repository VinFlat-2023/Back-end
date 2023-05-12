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