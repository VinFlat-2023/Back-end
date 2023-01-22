using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class RequestValidator : BaseValidator, IRequestValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public RequestValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Request? obj, int? requestId)
    {
        try
        {
            if (requestId != null)
                switch (obj?.RequestId)
                {
                    case { } when obj.RequestId != requestId:
                        ValidatorResult.Failures.Add("Request id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Request is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RequestCheck(obj.RequestId) == null)
                            ValidatorResult.Failures.Add("Request provided does not exist");
                        break;
                }

            switch (obj?.RequestName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.RequestName):
                    ValidatorResult.Failures.Add("Request name is required");
                    break;
                case { } when obj.RequestName.Length > 500:
                    ValidatorResult.Failures.Add("Request name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Request description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Request description cannot exceed 500 characters");
                    break;
            }

            if (obj?.CreateDate == null)
                ValidatorResult.Failures.Add("Create date is required");

            switch (obj?.Amount)
            {
                case { } when obj.Amount < 0:
                    ValidatorResult.Failures.Add("Invoice detail amount cannot be negative");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Invoice detail amount is required");
                    break;
            }

            switch (obj?.RequestTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Request type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RequestTypeCheck(obj.RequestTypeId) == null)
                        ValidatorResult.Failures.Add("Request type provided does not exist");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Request status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the request");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(RequestType? obj, int? requestTypeId)
    {
        try
        {
            if (requestTypeId != null)
                switch (obj?.RequestTypeId)
                {
                    case { } when obj.RequestTypeId != requestTypeId:
                        ValidatorResult.Failures.Add("Request id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Request type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RequestTypeCheck(obj.RequestTypeId) == null)
                            ValidatorResult.Failures.Add("Request type provided does not exist");
                        break;
                }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Request type description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Request type description cannot exceed 500 characters");
                    break;
            }

            switch (obj?.Name)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Request type name is required");
                    break;
                case { } when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Request type name cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Request type status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the request type");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}