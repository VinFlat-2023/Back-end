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
                case { Length: > 100 }:
                    ValidatorResult.Failures.Add("Password cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(password):
                    ValidatorResult.Failures.Add("Password is required");
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