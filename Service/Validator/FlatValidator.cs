using Domain.EntitiesForManagement;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
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

    public async Task<ValidatorResult> ValidateParams(FlatTypeUpdateRequest? flatType, int? flatId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(FlatTypeCreateRequest? flatType, CancellationToken flatId)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(FlatUpdateRequest? flat, int? flatId,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(FlatCreateRequest? flat, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(Flat? obj, int? flatId, CancellationToken token)
    {
        try
        {
            if (flatId != null)
                switch (obj?.FlatId)
                {
                    case not null when obj?.FlatId != flatId:
                        ValidatorResult.Failures.Add("Flat id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatCheck(obj.FlatId, token) == null)
                            ValidatorResult.Failures.Add("Flat provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Flat name is required");
                    break;
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Flat name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Flat description is required");
                    break;
                case not null when obj.Description.Length > 100:
                    ValidatorResult.Failures.Add("Flat description cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Flat status is required");

            if (obj?.WaterMeterBefore == null)
                ValidatorResult.Failures.Add("Flat water meter is required");

            if (obj?.ElectricityMeterBefore == null)
                ValidatorResult.Failures.Add("Flat electricity meter is required");

            if (obj?.WaterMeterAfter == null)
                ValidatorResult.Failures.Add("Flat water meter is required");

            if (obj?.ElectricityMeterAfter == null)
                ValidatorResult.Failures.Add("Flat electricity meter is required");

            if (flatId == null)
                switch (obj?.FlatTypeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Flat type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId, token) == null)
                            ValidatorResult.Failures.Add("Flat type provided does not exist");
                        break;
                }

            if (flatId == null)
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
            ValidatorResult.Failures.Add("An error occurred while validating the area");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(FlatType? obj, int? flatTypeId, CancellationToken token)
    {
        try
        {
            if (flatTypeId != null)
                switch (obj?.FlatTypeId)
                {
                    case not null when obj?.FlatTypeId != flatTypeId:
                        ValidatorResult.Failures.Add("Flat type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Flat type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.FlatTypeCheck(obj.FlatTypeId, token) == null)
                            ValidatorResult.Failures.Add("Flat type provided does not exist");
                        break;
                }


            switch (obj?.RoomCapacity)
            {
                case null:
                    ValidatorResult.Failures.Add("Flat type capacity is required");
                    break;
                case not null when obj.RoomCapacity < 1:
                    ValidatorResult.Failures.Add("Flat type capacity must be greater than 0");
                    break;
                case not null when obj.RoomCapacity > 20:
                    ValidatorResult.Failures.Add("Flat type capacity must be less than 20");
                    break;
            }

            if (flatTypeId == null)
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