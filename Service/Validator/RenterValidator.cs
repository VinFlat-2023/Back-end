using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IService;
using Service.IValidator;

namespace Service.Validator;

public class RenterValidator : BaseValidator, IRenterValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;
    private readonly IServiceWrapper _serviceWrapper;

    public RenterValidator(IConditionCheckHelper conditionCheckHelper, IServiceWrapper serviceWrapper)
    {
        _conditionCheckHelper = conditionCheckHelper;
        _serviceWrapper = serviceWrapper;
    }

    public async Task<ValidatorResult> ValidateParams(Renter? obj, int? renterId)
    {
        try
        {
            if (renterId != null)
                switch (obj?.RenterId)
                {
                    case { } when obj.RenterId != renterId:
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
                case { } when obj.Username.Length > 100:
                    ValidatorResult.Failures.Add("Username cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Username):
                    ValidatorResult.Failures.Add("Username is required");
                    break;
                /*

case not null:
if (renterId == null)
{
    if (await _conditionCheckHelper.AccountUsernameExist(obj.Username) != null)
        ValidatorResult.Failures.Add("Username is duplicated");
    if (await _conditionCheckHelper.RenterUsernameCheck(obj.Username) != null)
        ValidatorResult.Failures.Add("Username is duplicated");
}
break;
*/
            }

            switch (obj?.Email)
            {
                case { } when obj.Email.Length > 100:
                    ValidatorResult.Failures.Add("Email cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Email):
                    ValidatorResult.Failures.Add("Email is required");
                    break;
                case { } when !Regex.IsMatch(obj.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"):
                    ValidatorResult.Failures.Add("Email is invalid");
                    break;

                /*
                case not null:
                
                    if (await _conditionCheckHelper.AccountEmailCheck(obj.Email) != null)
                        ValidatorResult.Failures.Add("Email is duplicated");
                    if (await _conditionCheckHelper.RenterEmailCheck(obj.Email) != null)
                        ValidatorResult.Failures.Add("Email is duplicated");
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
            }

            switch (obj?.FullName)
            {
                case { } when obj.FullName.Length > 100:
                    ValidatorResult.Failures.Add("FullName cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.FullName):
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
                case { } when string.IsNullOrWhiteSpace(obj.CitizenNumber):
                    ValidatorResult.Failures.Add("Citizen number is required");
                    break;
                case { } when !validateNumber.IsMatch(obj.CitizenNumber):
                    ValidatorResult.Failures.Add("Phone number is invalid");
                    break;
                case { } when obj.CitizenNumber.Length > 20:
                    ValidatorResult.Failures.Add("Citizen number cannot exceed 20 characters");
                    break;
            }

            switch (obj?.Address)
            {
                case { } when obj.Address.Length > 100:
                    ValidatorResult.Failures.Add("Address cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("Address is required");
                    break;
            }

            if (obj?.MajorId != null && await _conditionCheckHelper.MajorCheck(obj.MajorId) == null)
                ValidatorResult.Failures.Add("Major provided does not exist");

            if (obj is { MajorId: { }, UniversityId: null })
                ValidatorResult.Failures.Add("University is required when major is provided");

            if (obj?.UniversityId != null)
            {
                if (await _conditionCheckHelper.UniversityCheck(obj.UniversityId) == null)
                    ValidatorResult.Failures.Add("University not found");

                if (obj.MajorId != null)
                {
                    var majorList = await _serviceWrapper.Majors.GetMajorListByUniversity(obj.UniversityId);
                    var majorExist = majorList.FirstOrDefault(x => x.MajorId == obj.MajorId);
                    if (majorExist == null)
                        ValidatorResult.Failures.Add("Major not found in this university");
                }
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