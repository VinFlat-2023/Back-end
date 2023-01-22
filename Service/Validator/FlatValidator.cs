using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class FlatValidator : BaseValidator, IFlatValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public FlatValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId)
    {
        try
        {
            if (flatId != null)
                switch (obj?.FlatId)
                {
                    case { } when obj?.FlatId != flatId:
                        ValidatorResult.Failures.Add("Flat id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId) == null)
                            ValidatorResult.Failures.Add("Flat provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Flat name is required");
                    break;
                case { } when obj.Name.Length > 200:
                    ValidatorResult.Failures.Add("Flat name max length reached");
                    break;
            }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Flat description is required");
                    break;
                case { } when obj.Description.Length > 200:
                    ValidatorResult.Failures.Add("Flat description max length reached");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Flat status is required");

            if (obj?.WaterMeter == null)
                ValidatorResult.Failures.Add("Flat water meter is required");

            if (obj?.ElectricityMeter == null)
                ValidatorResult.Failures.Add("Flat electricity meter is required");

            switch (obj?.FlatTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Flat type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId) == null)
                        ValidatorResult.Failures.Add("Flat type provided does not exist");
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
            ValidatorResult.Failures.Add("An error occurred while validating the area");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId)
    {
        try
        {
            if (flatTypeId != null)
                switch (obj?.FlatTypeId)
                {
                    case { } when obj?.FlatTypeId != flatTypeId:
                        ValidatorResult.Failures.Add("Flat type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId) == null)
                            ValidatorResult.Failures.Add("Flat type provided does not exist");
                        break;
                }

            switch (obj?.Capacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Flat type capacity is required");
                    break;
                case { } when obj.Capacity < 1:
                    ValidatorResult.Failures.Add("Flat type capacity must be greater than 0");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Flat type status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the flat");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}