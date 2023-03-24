using Domain.EntitiesForManagement;
using Service.IValidator;

namespace Service.Validator;

// TODO : TransactionValidator 
public class TransactionValidator : BaseValidator, ITransactionValidator
{
    public Task<ValidatorResult> ValidateParams(Transaction? obj)
    {
        throw new NotImplementedException();
    }
}