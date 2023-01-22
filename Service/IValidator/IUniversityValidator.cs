using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IUniversityValidator
{
    Task<ValidatorResult> ValidateParams(University? obj, int? universityId);
}