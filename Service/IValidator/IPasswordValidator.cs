using Service.Validator;

namespace Service.IValidator;

public interface IPasswordValidator
{
    public Task<ValidatorResult> ValidateParams(string password, int id, bool isRenter);
}