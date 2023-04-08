using System.Text.RegularExpressions;
using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class BuildingValidator : BaseValidator, IBuildingValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public BuildingValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Building? obj, int? buildingId)
    {
        try
        {
            if (buildingId != null)
                switch (obj?.BuildingId)
                {
                    case { } when obj.BuildingId != buildingId:
                        ValidatorResult.Failures.Add("Building id mismatch");
                        break;
                    case { } when await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null:
                        ValidatorResult.Failures.Add("Building provided does not exist");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                }

            switch (obj?.BuildingName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.BuildingName):
                    ValidatorResult.Failures.Add("Building name is required");
                    break;
                case { } when obj.BuildingName.Length > 200:
                    ValidatorResult.Failures.Add("Building mame cannot exceed 200 characters");
                    break;
            }

            switch (obj?.BuildingAddress)
            {
                case { } when string.IsNullOrWhiteSpace(obj.BuildingAddress):
                    ValidatorResult.Failures.Add("Building address is required");
                    break;

                case { } when obj.BuildingAddress.Length > 500:
                    ValidatorResult.Failures.Add("Building address cannot exceed 500 characters");
                    break;
            }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Building description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Building description cannot exceed 500 characters");
                    break;
            }

            if (obj?.CoordinateX == null)
                ValidatorResult.Failures.Add("Building coordinate x is required");

            if (obj?.CoordinateY == null)
                ValidatorResult.Failures.Add("Building coordinate y is required");

            var validatePhoneNumberRegex =
                new Regex("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$");

            switch (obj?.BuildingPhoneNumber)
            {
                case { } when string.IsNullOrWhiteSpace(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Phone is required");
                    break;
                case { } when !validatePhoneNumberRegex.IsMatch(obj.BuildingPhoneNumber):
                    ValidatorResult.Failures.Add("Phone number is invalid");
                    break;
            }

            switch (obj?.AreaId)
            {
                case null:
                    ValidatorResult.Failures.Add("Area id is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.AreaCheck(obj.AreaId) == null)
                        ValidatorResult.Failures.Add("Area provided does not exist");
                    break;
            }

            switch (obj?.AveragePrice)
            {
                case null:
                    ValidatorResult.Failures.Add("Average price is required");
                    break;
                case { } when obj.AveragePrice < 0:
                    ValidatorResult.Failures.Add("Average price cannot be less than 0");
                    break;
            }

            switch (obj?.EmployeeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Management employee is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId) == null)
                        ValidatorResult.Failures.Add("Management employee provided does not exist");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the building");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}