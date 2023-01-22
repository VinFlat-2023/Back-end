using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface ITransactionValidator
{
    Task<ValidatorResult> ValidateParams(Transaction? obj);
}