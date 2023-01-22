using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IRequestValidator
{
    Task<ValidatorResult> ValidateParams(Request? obj, int? requestId);

    Task<ValidatorResult> ValidateParams(RequestType? obj, int? requestTypeId);
}