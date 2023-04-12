using Domain.EntitiesForManagement;
using Domain.EntityRequest.Area;
using Service.Validator;

namespace Service.IValidator;

public interface IAreaValidator
{
    Task<ValidatorResult> ValidateParams(Area? obj, int? areaId);

    Task<ValidatorResult> ValidateParams(AreaUpdateRequest? obj, int? areaId);

    Task<ValidatorResult> ValidateParams(AreaCreateRequest? obj);
}