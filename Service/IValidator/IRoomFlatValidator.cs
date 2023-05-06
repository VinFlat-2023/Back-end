using Domain.EntityRequest.RoomFlat;
using Service.Validator;

namespace Service.IValidator;

public interface IRoomFlatValidator
{
    Task<ValidatorResult> ValidateParams(RoomFlatCreateRequest? obj, int? roomId, int? buildingId,
        CancellationToken token);

    Task<ValidatorResult> ValidateParams(RoomFlatUpdateRequest? obj, int? flatId, int? roomId, int? buildingId,
        CancellationToken token);
}