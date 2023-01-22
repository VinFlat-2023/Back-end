using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IMajorValidator
{
    Task<ValidatorResult> ValidateParams(Major? obj, int? majorId);
}