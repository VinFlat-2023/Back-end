using Domain.EntityRequest.Contract;
using Service.Validator;

namespace Service.IValidator;

public interface IContractValidator
{
    Task<ValidatorResult> ValidateParams(ContractUpdateRequest? obj, int? contractId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(ContractCreateRequest? obj, int buildingId, CancellationToken cancellationToken);
    Task<ValidatorResult> ValidateParams(ContractCreateUserExistRequest? obj, int? renterId, int buildingId, CancellationToken cancellationToken);

}