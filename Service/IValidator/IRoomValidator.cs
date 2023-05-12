using Domain.EntityRequest.Room;
using Service.Validator;

namespace Service.IValidator;

public interface IRoomValidator
{
    Task<ValidatorResult> ValidateParams(RoomCreateRequest? obj, int? roomId, int? buildingId,
        CancellationToken token);

    Task<ValidatorResult> ValidateParams(RoomUpdateRequest? obj, int? flatId, int? roomId, int? buildingId,
        CancellationToken token);
}