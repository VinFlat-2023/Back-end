using System.Text.RegularExpressions;
using Domain.EntityRequest.Renter;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class RenterValidator : BaseValidator, IRenterValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public RenterValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    /*
    public async Task<ValidatorResult> ValidateParams(Renter? renter, int? renterId, CancellationToken token)
    {
        try
        {
            switch (renter)
            {
                case null :
                    ValidatorResult.Failures.Add("Thông tin không được bỏ trống");
                    break;
                case not null when renterId == null : 
                    ValidatorResult.Failures.Add("Khách thuê không tồn tại");
                    break;
                case not null :
                    var renterCheck = await _conditionCheckHelper.RenterCheck(renterId);
                    switch (renterCheck)
                    {
                        case null : 
                            ValidatorResult.Failures.Add("Khách thuê không tồn tại");
                            break;
                        case not null :
                            var renter = await _conditionCheckHelper.RenterUsernameCheck(renter.Username, token);
                                {
                                    ValidatorResult.Failures.Add("Tên đăng nhập đã tồn tại");
                                }
                                
                            if (renterCheck.Email != renter.Email)
                            {
                                if (await _conditionCheckHelper.RenterEmailCheck(renter.Email) != null)
                                {
                                    ValidatorResult.Failures.Add("Email đã tồn tại");
                                }
                            }
                                
                            if (renterCheck.PhoneNumber != renter.PhoneNumber)
                            {
                                if (await _conditionCheckHelper.RenterPhoneNumberCheck(renter.PhoneNumber) != null)
                                {
                                    ValidatorResult.Failures.Add("Số điện thoại đã tồn tại");
                                }
                            }
                                
                            break;
                    }
            if (renterId != null)
                switch (obj?.RenterId)
                {
                    case not null when obj.RenterId != renterId:
                        ValidatorResult.Failures.Add("Renter id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Renter is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                            ValidatorResult.Failures.Add("Renter provided does not exist");
                        break;
                }

                switch (obj?.Username)
                {
                    case not null when obj.Username.Length > 100:
                        ValidatorResult.Failures.Add("Username cannot exceed 100 characters");
                        break;
                    case not null when string.IsNullOrWhiteSpace(obj.Username):
                        ValidatorResult.Failures.Add("Username is required");
                        break;
                    case not null when obj.Username.Length < 4:
                        ValidatorResult.Failures.Add("Username must be at least 4 characters");
                        break;
                    case not null when await _conditionCheckHelper.EmployeeUsernameExist(obj.Username) != null:
                        ValidatorResult.Failures.Add("Username is duplicated");
                        break;
                    case not null when await _conditionCheckHelper.RenterUsernameCheck(obj.Username) != null:
                        ValidatorResult.Failures.Add("Username is duplicated");
                        break;
                    case { } when obj.Username.Contains(' '):
                        ValidatorResult.Failures.Add("Username cannot contain spaces");
                        break;
                }

            switch (obj?.Email)
            {
                case not null when obj.Email.Length > 100:
                    ValidatorResult.Failures.Add("Email cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Email):
                    ValidatorResult.Failures.Add("Email is required");
                    break;
                case not null when obj.Email.Length < 8:
                    ValidatorResult.Failures.Add("Email must be at least 8 characters");
                    break;
                case not null when !Regex.IsMatch(obj.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Email is invalid");
                    break;
                case not null :
                    if (await _conditionCheckHelper.RenterEmailCheck(obj.Email, renterId, token) != null)
                    {
                        ValidatorResult.Failures.Add("Email is duplicated");
                    } 

                    if (await _conditionCheckHelper.EmployeeEmailCheck(obj.Email) != null)
                    {
                        ValidatorResult.Failures.Add("Email is duplicated");
                    }
                    break;
            }

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.Phone)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Phone):
                    ValidatorResult.Failures.Add("Phone is required");
                    break;
                case not null when !validatePhoneNumberRegex.IsMatch(obj.Phone):
                    ValidatorResult.Failures.Add("Phone number is invalid");
                    break;
            }

            switch (obj?.FullName)
            {
                case not null when obj.FullName.Length > 100:
                    ValidatorResult.Failures.Add("FullName cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.FullName):
                    ValidatorResult.Failures.Add("FullName is required");
                    break;
            }

            if (obj?.BirthDate == null)
                ValidatorResult.Failures.Add("Birthdate is required");

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");


            var validateNumber = new Regex("^[0-9]+$");

            switch (obj?.CitizenNumber)
            {
                case not null when string.IsNullOrWhiteSpace(obj.CitizenNumber):
                    ValidatorResult.Failures.Add("Citizen number is required");
                    break;
                case not null when !validateNumber.IsMatch(obj.CitizenNumber):
                    ValidatorResult.Failures.Add("Phone number is invalid");
                    break;
                case not null when obj.CitizenNumber.Length > 20:
                    ValidatorResult.Failures.Add("Citizen number cannot exceed 20 characters");
                    break;
            }

            switch (obj?.Address)
            {
                case not null when obj.Address.Length > 100:
                    ValidatorResult.Failures.Add("Address cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("Address is required");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the renter");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
    */

    public async Task<ValidatorResult> ValidateParams(RenterUpdateRequest? obj, int? renterId, CancellationToken token)
    {
        try
        {
            switch (renterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Người thuê là bắt buộc");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(renterId, token) == null)
                        ValidatorResult.Failures.Add("Người thuê không tồn tại");
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
                    var employee = await _conditionCheckHelper.RenterEmailCheck(obj.Email, renterId, token);
                    switch (employee.IsSuccess)
                    {
                        case true:
                            break;
                        case false:
                            ValidatorResult.Failures.Add(employee.Message);
                            break;
                    }

                    var renter = await _conditionCheckHelper.EmployeeEmailCheck(obj.Email, token);
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

            switch (obj?.FullName)
            {
                case not null when obj.FullName.Length > 100:
                    ValidatorResult.Failures.Add("Họ và tên không được vượt quá 100 ký tự");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.FullName):
                    ValidatorResult.Failures.Add("Họ và tên không được để trống");
                    break;
                case not null when obj.FullName.Length < 4:
                    ValidatorResult.Failures.Add("Họ và tên không được nhỏ hơn 4 ký tự");
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


            if (obj?.BirthDate == null)
                ValidatorResult.Failures.Add("Birthdate is required");

            switch (obj?.Address)
            {
                case not null when obj.Address.Length > 100:
                    ValidatorResult.Failures.Add("Address cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("Address is required");
                    break;
            }

            switch (obj?.Gender)
            {
                case null:
                    ValidatorResult.Failures.Add("Giới tính là bắt buộc");
                    break;
                case not null:
                    if (obj.Gender.ToLower() == "nữ".ToLower() || obj.Gender.ToLower() == "nam".ToLower())
                        break;
                    ValidatorResult.Failures.Add("Giới tính không hợp lệ");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the renter");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}