using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class ServiceValidator : BaseValidator, IServiceValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public ServiceValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(ServiceEntity? obj, int? serviceId)
    {
        try
        {
            if (serviceId != null)
                switch (obj?.ServiceId)
                {
                    case { } when obj.ServiceId != serviceId:
                        ValidatorResult.Failures.Add("Service id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ServiceCheck(obj.ServiceId) == null)
                            ValidatorResult.Failures.Add("Service provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case { } when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Service cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Service name is required");
                    break;
            }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Service description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Service description cannot exceed 500 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");

            switch (obj?.ServiceTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Service type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.ServiceTypeCheck(obj.ServiceTypeId) == null)
                        ValidatorResult.Failures.Add("Service type provided does not exist");
                    break;
            }

            switch (obj?.BuildingId)
            {
                case null:
                    ValidatorResult.Failures.Add("Building is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null)
                        ValidatorResult.Failures.Add("Building provided does not exist");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the service");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(ServiceType? obj, int? serviceTypeId)
    {
        try
        {
            if (serviceTypeId != null)
                switch (obj?.ServiceTypeId)
                {
                    case { } when obj.ServiceTypeId != serviceTypeId:
                        ValidatorResult.Failures.Add("Service type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Renter is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ServiceTypeCheck(obj.ServiceTypeId) == null)
                            ValidatorResult.Failures.Add("Service type provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case { } when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Service type cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Service type name is required");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the service type");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}