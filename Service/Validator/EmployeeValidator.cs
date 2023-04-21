using System.Text.RegularExpressions;
using Domain.EntityRequest.Employee;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class EmployeeValidator : BaseValidator, IEmployeeValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public EmployeeValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(EmployeeUpdateRequest? obj, int? employeeId,
        CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Dữ liệu không được để trống");
            if (await _conditionCheckHelper.EmployeeCheck(employeeId, token) == null)
                ValidatorResult.Failures.Add("Nhân viên không tồn tại");

            switch (obj?.Fullname)
            {
                case not null when obj.Fullname.Length > 100:
                    ValidatorResult.Failures.Add("Tên không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Fullname):
                    ValidatorResult.Failures.Add("Tên không được để trống");
                    break;
            }

            switch (obj?.Email)
            {
                case not null when obj.Email.Length > 100:
                    ValidatorResult.Failures.Add("Địa chỉ email không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Email):
                    ValidatorResult.Failures.Add("Địa chỉ email không được để trống");
                    break;
                case not null when !Regex.IsMatch(obj.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Địa chỉ email không hợp lệ");
                    break;
                case not null:
                    var employee = await _conditionCheckHelper.EmployeeEmailCheck(obj.Email, employeeId, token);
                    switch (employee.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(employee.Message);
                            break;
                    }

                    var renter = await _conditionCheckHelper.RenterEmailCheck(obj.Email, token);
                    switch (renter.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(renter.Message);
                            break;
                    }

                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.Phone)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Phone):
                    ValidatorResult.Failures.Add("Số điện thoại không được để trống");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.Phone):
                    ValidatorResult.Failures.Add("Số điện thoại không hợp lệ");
                    break;
                case not null when obj.Phone.Length > 13:
                    ValidatorResult.Failures.Add("Số điện thoại không được vượt quá 13 ký tự");
                    break;
                case not null when obj.Phone.Length < 7:
                    ValidatorResult.Failures.Add("Số điện thoại không được ít hơn 7 ký tự");
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

    public async Task<ValidatorResult> ValidateParams(EmployeeCreateRequest? obj, CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Dữ liệu không được để trống");
            switch (obj?.Username)
            {
                case not null when obj.Username.Length > 100:
                    ValidatorResult.Failures.Add("Tên đăng nhập không được vượt quá 100 ký tự");
                    break;
                case not null when obj.Username.Length < 4:
                    ValidatorResult.Failures.Add("Tên đăng nhập không được ít hơn 4 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Username):
                    ValidatorResult.Failures.Add("Tên đăng nhập không được để trống");
                    break;
                case not null:
                    var employee = await _conditionCheckHelper.EmployeeUsernameExist(obj.Username, token);
                    switch (employee.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(employee.Message);
                            break;
                    }

                    var renter = await _conditionCheckHelper.RenterUsernameCheck(obj.Username, token);
                    switch (renter.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(renter.Message);
                            break;
                    }

                    break;
            }

            switch (obj?.Fullname)
            {
                case not null when obj.Fullname.Length > 100:
                    ValidatorResult.Failures.Add("Tên nhân viên không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Fullname):
                    ValidatorResult.Failures.Add("Tên không được để trống");
                    break;
            }

            switch (obj?.Email)
            {
                case not null when obj.Email.Length > 100:
                    ValidatorResult.Failures.Add("Địa chỉ email không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Email):
                    ValidatorResult.Failures.Add("Địa chỉ email không được để trống");
                    break;
                case not null when !Regex.IsMatch(obj.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Địa chỉ email không hợp lệ");
                    break;
                case not null:
                    var employee = await _conditionCheckHelper.EmployeeEmailCheck(obj.Email, token);
                    switch (employee.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(employee.Message);
                            break;
                    }

                    var renter = await _conditionCheckHelper.RenterEmailCheck(obj.Email, token);
                    switch (renter.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(renter.Message);
                            break;
                    }

                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.Phone)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Phone):
                    ValidatorResult.Failures.Add("Số điện thoại không được để trống");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.Phone):
                    ValidatorResult.Failures.Add("Số điện thoại không hợp lệ");
                    break;
                case not null when obj.Phone.Length > 13:
                    ValidatorResult.Failures.Add("Số điện thoại không được vượt quá 13 ký tự");
                    break;
                case not null when obj.Phone.Length < 7:
                    ValidatorResult.Failures.Add("Số điện thoại không được ít hơn 7 ký tự");
                    break;
                case not null:
                    var employee = await _conditionCheckHelper.EmployeeEmailCheck(obj.Email, token);
                    switch (employee.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(employee.Message);
                            break;
                    }

                    var renter = await _conditionCheckHelper.RenterEmailCheck(obj.Email, token);
                    switch (renter.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(renter.Message);
                            break;
                    }

                    break;
            }

            switch (obj?.RoleId)
            {
                case null:
                    ValidatorResult.Failures.Add("Vai trò không được để trống");
                    break;
                case not null:
                    var roleValidation = await _conditionCheckHelper.RoleCheck(obj.RoleId, token);
                    switch (roleValidation)
                    {
                        case null:
                            ValidatorResult.Failures.Add("Vai trò không tồn tại");
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