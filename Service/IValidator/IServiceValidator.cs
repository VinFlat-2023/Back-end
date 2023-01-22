using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IServiceValidator
{
    Task<ValidatorResult> ValidateParams(ServiceEntity? obj, int? serviceId);

    Task<ValidatorResult> ValidateParams(ServiceType? obj, int? serviceTypeId);
}