using Domain.EntityRequest.Room;
using Service.Validator;

namespace Service.IValidator;

public interface IRoomValidator
{
    Task<ValidatorResult> ValidateParams(RoomUpdateRequest? obj, int? roomId,
        CancellationToken token);
}