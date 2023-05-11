using Domain.EntityRequest.RoomType;
using Service.Validator;

namespace Service.IValidator;

public interface IRoomTypeValidator
{
    Task<ValidatorResult> ValidateParams(RoomTypeUpdateRequest? obj, int? roomId, int? buildingId,
        CancellationToken token);

    Task<ValidatorResult> ValidateParams(RoomTypeCreateRequest? obj, int? buildingId, CancellationToken token);
}