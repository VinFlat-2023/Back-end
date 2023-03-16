using Service.Validator;

namespace Service.IValidator;

public interface IPaymentValidator
{
    Task<ValidatorResult> ValidateParams(int invoiceId, int userId, int amount);
}