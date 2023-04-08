using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class EmployeeValidator : BaseValidator, IEmployeeValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;
    private readonly IJwtRoleCheckerHelper _jwtRoleCheckerHelper;

    public EmployeeValidator(IConditionCheckHelper conditionCheckHelper, IJwtRoleCheckerHelper jwtRoleCheckerHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
        _jwtRoleCheckerHelper = jwtRoleCheckerHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Employee? obj, int? employeeId, bool isUpdate)
    {
        try
        {
            if (employeeId != null)
                switch (obj?.EmployeeId)
                {
                    case { } when obj.EmployeeId != employeeId:
                        ValidatorResult.Failures.Add("Employee id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Employee is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId) == null)
                            ValidatorResult.Failures.Add("Employee provided does not exist");
                        break;
                }

            switch (obj?.Username)
            {
                case { } when obj.Username.Length > 100:
                    ValidatorResult.Failures.Add("Username cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Username):
                    ValidatorResult.Failures.Add("Username is required");
                    break;
                case not null:
                    /*
                    if (employeeId == null)
                    {
                        if (await _conditionCheckHelper.EmployeeUsernameExist(obj.Username) != null)
                            ValidatorResult.Failures.Add("Username is duplicated");
                        if (await _conditionCheckHelper.RenterUsernameCheck(obj.Username) != null)
                            ValidatorResult.Failures.Add("Username is duplicated");
                    }
                    */
                    break;
            }

            switch (obj?.FullName)
            {
                case { } when obj.FullName.Length > 100:
                    ValidatorResult.Failures.Add("Name cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.FullName):
                    ValidatorResult.Failures.Add("Name is required");
                    break;
            }

            if (!isUpdate)
                switch (obj?.Password)
                {
                    case { } when obj.Password.Length > 100:
                        ValidatorResult.Failures.Add("Password cannot exceed 100 characters");
                        break;
                    case { } when string.IsNullOrWhiteSpace(obj.Password):
                        ValidatorResult.Failures.Add("Password is required");
                        break;
                }

            switch (obj?.Email)
            {
                case { } when obj.Email.Length > 256:
                    ValidatorResult.Failures.Add("Email cannot exceed 256 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Email):
                    ValidatorResult.Failures.Add("Email is required");
                    break;
                case { } when !Regex.IsMatch(obj.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Email is invalid");
                    break;
                /*

case not null:
if (employeeId == null)
{
   if (await _conditionCheckHelper.EmployeeUsernameExist(obj.Username) != null)
       ValidatorResult.Failures.Add("Username is duplicated");
   if (await _conditionCheckHelper.RenterUsernameCheck(obj.Username) != null)
       ValidatorResult.Failures.Add("Username is duplicated");
}
break;
*/
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.Phone)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Phone):
                    ValidatorResult.Failures.Add("Phone is required");
                    break;
                case { } when !validatePhoneNumberRegex.IsMatch(obj.Phone):
                    ValidatorResult.Failures.Add("Phone number is invalid");
                    break;
                case { } when obj.Phone.Length > 13:
                    ValidatorResult.Failures.Add("Phone number cannot exceed 13 characters");
                    break;
                case { } when obj.Phone.Length < 7:
                    ValidatorResult.Failures.Add("Phone number cannot be less than 7 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");

            if (isUpdate)
                switch (obj?.RoleId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Role is required");
                        break;
                    case not null:
                        var roleValidation = await _conditionCheckHelper.RoleCheck(obj.RoleId);
                        switch (roleValidation)
                        {
                            case null:
                                ValidatorResult.Failures.Add("Role provided does not exist");
                                break;
                        }

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