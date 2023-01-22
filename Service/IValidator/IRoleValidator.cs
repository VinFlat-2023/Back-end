using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IRoleValidator
{
    Task<ValidatorResult> ValidateParams(Role? obj, int? roleId);
}