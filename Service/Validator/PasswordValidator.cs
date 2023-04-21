using Domain.EntityRequest.Employee;
using Domain.EntityRequest.Renter;
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

    public async Task<ValidatorResult> ValidateParams(RenterUpdatePasswordRequest? renter, int? renterId,
        CancellationToken token)
    {
        try
        {
            switch (renter)
            {
                case null:
                    ValidatorResult.Failures.Add("Dòng thông tin không được để trống");
                    break;
                case not null when renterId == null:
                    ValidatorResult.Failures.Add("Khách thuê không tồn tại");
                    break;
                case not null:
                    var renterCheck = await _conditionCheckHelper.RenterCheck(renterId, token);
                    switch (renterCheck)
                    {
                        case null:
                            ValidatorResult.Failures.Add("Nhân viên không tồn tại");
                            break;
                        case not null:
                            if (renterCheck.Password != renter.OldPassword)
                                ValidatorResult.Failures.Add("Mật khẩu cũ không đúng");
                            break;
                    }

                    if (renter.Password.Length < 5 || renter.ConfirmPassword.Length < 5)
                        ValidatorResult.Failures.Add("Mật khẩu phải có ít nhất 6 ký tự");
                    if (renter.Password.Length > 30 || renter.ConfirmPassword.Length > 30)
                        ValidatorResult.Failures.Add("Mật khẩu không được vượt quá 30 ký tự");
                    if (string.IsNullOrWhiteSpace(renter.Password) || string.IsNullOrWhiteSpace(renter.ConfirmPassword))
                        ValidatorResult.Failures.Add("Mật khẩu không được để trống");
                    if (renter.Password != renter.ConfirmPassword)
                        ValidatorResult.Failures.Add("Mật khẩu và mật khẩu xác nhận không khớp");
                    if (!renter.Password.Any(char.IsUpper) || !renter.ConfirmPassword.Any(char.IsUpper))
                        ValidatorResult.Failures.Add("Mật khẩu phải chứa ít nhất một chữ cái viết hoa");
                    if (renter.Password.Contains(' ') || renter.ConfirmPassword.Contains(' '))
                        ValidatorResult.Failures.Add("Mật khẩu không được chứa khoảng trắng");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the renter password");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(EmployeeUpdatePasswordRequest? employee, int? employeeId,
        CancellationToken token)
    {
        try
        {
            switch (employee)
            {
                case null:
                    ValidatorResult.Failures.Add("Dòng thông tin không được để trống");
                    break;
                case not null when employeeId == null:
                    ValidatorResult.Failures.Add("Nhân viên không tồn tại");
                    break;
                case not null:
                    var employeeCheck = await _conditionCheckHelper.EmployeeCheck(employeeId, token);
                    switch (employeeCheck)
                    {
                        case null:
                            ValidatorResult.Failures.Add("Nhân viên không tồn tại");
                            break;
                        case not null:
                            if (employeeCheck.Password != employee.OldPassword)
                                ValidatorResult.Failures.Add("Mật khẩu cũ không đúng");
                            break;
                    }

                    if (employee.Password.Length < 5 || employee.ConfirmPassword.Length < 5)
                        ValidatorResult.Failures.Add("Mật khẩu phải có ít nhất 6 ký tự");
                    if (employee.Password.Length > 30 || employee.ConfirmPassword.Length > 30)
                        ValidatorResult.Failures.Add("Mật khẩu không được vượt quá 30 ký tự");
                    if (string.IsNullOrWhiteSpace(employee.Password) ||
                        string.IsNullOrWhiteSpace(employee.ConfirmPassword))
                        ValidatorResult.Failures.Add("Mật khẩu không được để trống");
                    if (employee.Password != employee.ConfirmPassword)
                        ValidatorResult.Failures.Add("Mật khẩu và mật khẩu xác nhận không khớp");
                    if (!employee.Password.Any(char.IsUpper) || !employee.ConfirmPassword.Any(char.IsUpper))
                        ValidatorResult.Failures.Add("Mật khẩu phải chứa ít nhất một chữ cái viết hoa");
                    if (employee.Password.Contains(' ') || employee.ConfirmPassword.Contains(' '))
                        ValidatorResult.Failures.Add("Mật khẩu không được chứa khoảng trắng");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the employee password");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}