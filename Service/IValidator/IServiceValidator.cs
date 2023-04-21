using Domain.EntitiesForManagement;
using Domain.EntityRequest.Service;
using Domain.EntityRequest.ServiceType;
using Service.Validator;

namespace Service.IValidator;

public interface IServiceValidator
{
    Task<ValidatorResult> ValidateParams(ServiceEntity? obj, int? serviceId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(ServiceCreateRequest? service, CancellationToken token);
    Task<ValidatorResult> ValidateParams(ServiceUpdateRequest? service, int? serviceId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(ServiceType? obj, int? serviceTypeId, CancellationToken token);

    Task<ValidatorResult> ValidateParams(ServiceTypeCreateRequest? serviceType, int? serviceTypeId,
        CancellationToken token);

    Task<ValidatorResult> ValidateParams(ServiceTypeCreateRequest? serviceType, CancellationToken serviceTypeId);
}