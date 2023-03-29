using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IBuildingValidator
{
    Task<ValidatorResult> ValidateParams(Building obj, int? buildingId);
}