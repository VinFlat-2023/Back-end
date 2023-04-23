using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IRoomValidator
{
    Task<ValidatorResult> ValidateParams(Room? obj, int? roomId, CancellationToken token);
    //Task<ValidatorResult> ValidateParams(RoomType? obj, int? roomTypeId);
}