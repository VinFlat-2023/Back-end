using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IRoomValidator
{
    Task<ValidatorResult> ValidateParams(Room? obj, int? roomId);
    Task<ValidatorResult> ValidateParams(RoomType? obj, int? roomTypeId);
}