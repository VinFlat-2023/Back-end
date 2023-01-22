using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IAreaValidator
{
    Task<ValidatorResult> ValidateParams(Area? obj, int? areaId);
}