using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IAccountValidator
{
    Task<ValidatorResult> ValidateParams(Account obj, int? accountId, bool isUpdate);
}