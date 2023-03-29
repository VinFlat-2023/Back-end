using System.Dynamic;
using Domain.EntitiesForManagement;
using Microsoft.IdentityModel.Tokens;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class BuildingValidator : BaseValidator, IBuildingValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;
    private readonly IDynamicObjectPropertyExistExtension _dynamic;
    public BuildingValidator(IConditionCheckHelper conditionCheckHelper, IDynamicObjectPropertyExistExtension dynamic)
    {
        _conditionCheckHelper = conditionCheckHelper;
        _dynamic = dynamic;
    }
    

    public async Task<ValidatorResult> ValidateParams(Building obj, int? buildingId)
    {
        dynamic? dynamicObject = obj;

        try
        {
            if (_dynamic.DoesPropertyExist(dynamicObject, obj.BuildingId.ToString()))
                switch (obj.BuildingId)
                {
                    case { } when obj.BuildingId != buildingId :
                        ValidatorResult.Failures.Add("Building id mismatch");
                        break;
                    case { } when obj.BuildingId.ToString().IsNullOrEmpty() :
                        ValidatorResult.Failures.Add("Building is required");
                        break;
                    case { } when await _conditionCheckHelper.BuildingCheck(obj.BuildingId) == null :
                        ValidatorResult.Failures.Add("Building provided does not exist");
                        break;
                }

            switch (obj?.AreaId)
            {
                case null:
                    ValidatorResult.Failures.Add("Area id mismatch");
                    break;
                case not null:
                    if (await _conditionCheckHelper.AreaCheck(obj.AreaId) == null)
                        ValidatorResult.Failures.Add("Area provided does not exist");
                    break;
            }

            switch (obj?.BuildingName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.BuildingName):
                    ValidatorResult.Failures.Add("Building name is required");
                    break;
                case { } when obj.BuildingName.Length > 100:
                    ValidatorResult.Failures.Add("Building mame cannot exceed 100 characters");
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

            switch (obj?.TotalRooms)
            {
                case { } when string.IsNullOrWhiteSpace(obj.TotalRooms.ToString()):
                    ValidatorResult.Failures.Add("Building total room is required");
                    break;
                case { } when obj.TotalRooms > 500:
                    ValidatorResult.Failures.Add("Building total room cannot exceed 500");
                    break;
            }

            if (obj?.CoordinateX == null)
                ValidatorResult.Failures.Add("Building coordinate x is required");

            if (obj?.CoordinateY == null)
                ValidatorResult.Failures.Add("Building coordinate y is required");

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