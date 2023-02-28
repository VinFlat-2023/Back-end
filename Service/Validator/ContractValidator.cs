using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class ContractValidator : BaseValidator, IContractValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public ContractValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Contract? obj, int? contractId)
    {
        try
        {
            if (contractId != null)
                switch (obj?.ContractId)
                {
                    case { } when obj.ContractId != contractId:
                        ValidatorResult.Failures.Add("Contract id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Contract is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ContractCheck(obj.ContractId) == null)
                            ValidatorResult.Failures.Add("Contract provided does not exist");
                        break;
                }

            if (obj?.DateSigned == null)
                ValidatorResult.Failures.Add("Date signed is required");

            if (obj?.StartDate == null)
                ValidatorResult.Failures.Add("Start date is required");

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Contract description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Contract description cannot exceed 100 characters");
                    break;
            }

            if (obj?.EndDate == null)
                ValidatorResult.Failures.Add("End date is required");

            if (obj?.ContractStatus == null)
                ValidatorResult.Failures.Add("Contract status is required");

            switch (obj?.PriceForRent)
            {
                case { } when obj.PriceForRent <= 0:
                    ValidatorResult.Failures.Add("PriceForRent must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("PriceForRent is required");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the contract");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}