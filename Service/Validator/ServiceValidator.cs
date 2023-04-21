using Domain.EntitiesForManagement;
using Domain.EntityRequest.Service;
using Domain.EntityRequest.ServiceType;
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

    public async Task<ValidatorResult> ValidateParams(ServiceEntity? obj, int? serviceId, CancellationToken token)
    {
        try
        {
            if (serviceId != null)
                switch (obj?.ServiceId)
                {
                    case not null when obj.ServiceId != serviceId:
                        ValidatorResult.Failures.Add("Service id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ServiceCheck(obj.ServiceId, token) == null)
                            ValidatorResult.Failures.Add("Service provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Service cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Service name is required");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Service description is required");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Service description cannot exceed 500 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");

            if (serviceId == null)
                switch (obj?.ServiceTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Service type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ServiceTypeCheck(obj.ServiceTypeId, token) == null)
                            ValidatorResult.Failures.Add("Service type provided does not exist");
                        break;
                }

            if (serviceId == null)
                switch (obj?.BuildingId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.BuildingCheck(obj.BuildingId, token) == null)
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

    public Task<ValidatorResult> ValidateParams(ServiceCreateRequest? service, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<ValidatorResult> ValidateParams(ServiceUpdateRequest? service, int? serviceId, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(ServiceType? obj, int? serviceTypeId, CancellationToken token)
    {
        try
        {
            if (serviceTypeId != null)
                switch (obj?.ServiceTypeId)
                {
                    case not null when obj.ServiceTypeId != serviceTypeId:
                        ValidatorResult.Failures.Add("Service type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Renter is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ServiceTypeCheck(obj.ServiceTypeId, token) == null)
                            ValidatorResult.Failures.Add("Service type provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Service type cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
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

    public Task<ValidatorResult> ValidateParams(ServiceTypeCreateRequest? serviceType, int? serviceTypeId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public Task<ValidatorResult> ValidateParams(ServiceTypeCreateRequest? serviceType, CancellationToken serviceTypeId)
    {
        throw new NotImplementedException();
    }
}