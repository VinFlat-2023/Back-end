using Domain.EntityRequest.RoomFlat;
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

    public Task<ValidatorResult> ValidateParams(RoomFlatCreateRequest? obj, int? roomId, int? buildingId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<ValidatorResult> ValidateParams(RoomFlatUpdateRequest? obj, int? flatId, int? roomId, int? buildingId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }
}