using Domain.EntityRequest.Building;
using Service.Validator;

namespace Service.IValidator;

public interface IBuildingValidator
{
    Task<ValidatorResult> ValidateParams(BuildingUpdateRequest? obj, int? buildingId, CancellationToken token);

    Task<ValidatorResult> ValidateParams(BuildingCreateRequest? obj, CancellationToken token);
}