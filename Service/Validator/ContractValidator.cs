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

            switch (obj?.ContractName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.ContractName):
                    ValidatorResult.Failures.Add("Contract name is required");
                    break;
                case { } when obj.ContractName.Length > 200:
                    ValidatorResult.Failures.Add("Contract name cannot exceed 200 characters");
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
                    ValidatorResult.Failures.Add("Contract description cannot exceed 500 characters");
                    break;
            }

            if (obj?.EndDate == null)
                ValidatorResult.Failures.Add("End date is required");

            if (obj?.ContractStatus == null)
                ValidatorResult.Failures.Add("Contract status is required");

            switch (obj?.PriceForRent)
            {
                case { } when obj.PriceForRent <= 0:
                    ValidatorResult.Failures.Add("Rent price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Rent price is required");
                    break;
            }

            switch (obj?.PriceForElectricity)
            {
                case { } when obj.PriceForElectricity <= 0:
                    ValidatorResult.Failures.Add("Electricity price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Electricity price is required");
                    break;
            }

            switch (obj?.PriceForWater)
            {
                case { } when obj.PriceForWater <= 0:
                    ValidatorResult.Failures.Add("Water price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Water price is required");
                    break;
            }

            switch (obj?.PriceForService)
            {
                case { } when obj.PriceForService <= 0:
                    ValidatorResult.Failures.Add("Service price must be greater than 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Service price is required");
                    break;
            }

            if (contractId == null)
                switch (obj?.RenterId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Renter is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                            ValidatorResult.Failures.Add("Renter provided does not exist");
                        break;
                }

            if (contractId == null)
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

            if (contractId == null)
                switch (obj?.FlatId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                            ValidatorResult.Failures.Add("Flat provided does not exist");
                        break;
                }

            if (contractId == null)
                switch (obj?.RoomId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Room is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RoomCheck(obj.RoomId) == null)
                            ValidatorResult.Failures.Add("Room provided does not exist");
                        break;
                }
            // TODO : Flat and Room check validation
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the contract");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}