using Domain.EntitiesForManagement;
using Domain.EntityRequest.Contract;
using Service.Validator;

namespace Service.IValidator;

public interface IContractValidator
{
    Task<ValidatorResult> ValidateParams(Contract? obj, int? contractId);

    Task<ValidatorResult> ValidateParams(ContractUpdateRequest? obj, int? contractId);

    Task<ValidatorResult> ValidateParams(ContractCreateRequest? obj);
}