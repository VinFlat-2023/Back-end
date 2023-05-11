using Domain.EntityRequest.Area;
using Service.Validator;

namespace Service.IValidator;

public interface IAreaValidator
{
    Task<ValidatorResult> ValidateParams(AreaUpdateRequest? obj, int? areaId, CancellationToken token);

    Task<ValidatorResult> ValidateParams(AreaCreateRequest? obj, CancellationToken token);
}