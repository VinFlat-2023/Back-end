using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class PasswordValidator : BaseValidator, IPasswordValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public PasswordValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(string password, int id, bool isRenter)
    {
        try
        {
            switch (password)
            {
                case { Length: > 30 }:
                    ValidatorResult.Failures.Add("Password cannot exceed 30 characters");
                    break;
                case null or not null when string.IsNullOrWhiteSpace(password):
                    ValidatorResult.Failures.Add("Password is required");
                    break;
                case { Length: < 5 }:
                    ValidatorResult.Failures.Add("Password must be at least 6 characters");
                    break;
                case not null when !password.Any(char.IsUpper):
                    ValidatorResult.Failures.Add("Password must contain at least one uppercase letter");
                    break;
                case { } when password.Contains(' '):
                    ValidatorResult.Failures.Add("Password cannot contain spaces");
                    break;
            }

            switch (isRenter)
            {
                case true:
                    if (await _conditionCheckHelper.RenterCheck(id) == null)
                        ValidatorResult.Failures.Add("Renter provided does not exist");
                    break;
                case false:
                    if (await _conditionCheckHelper.EmployeeCheck(id) == null)
                        ValidatorResult.Failures.Add("Employee provided does not exist");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the employee");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}