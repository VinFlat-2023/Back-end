using Domain.EntitiesForManagement;
using Domain.EntityRequest.Building;
using Service.Validator;

namespace Service.IValidator;

public interface IBuildingValidator
{
    Task<ValidatorResult> ValidateParams(Building? obj, int? buildingId);

    Task<ValidatorResult> ValidateParams(BuildingUpdateRequest? obj, int? buildingId);

    Task<ValidatorResult> ValidateParams(BuildingCreateRequest? obj);
}