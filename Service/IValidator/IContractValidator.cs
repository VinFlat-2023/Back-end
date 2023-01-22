using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IContractValidator
{
    Task<ValidatorResult> ValidateParams(Contract? obj, int? contractId);

    Task<ValidatorResult> ValidateParams(ContractHistory? obj, int? contractHistoryId);
}