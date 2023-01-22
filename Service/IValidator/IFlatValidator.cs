using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IFlatValidator
{
    Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId);

    Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId);
}