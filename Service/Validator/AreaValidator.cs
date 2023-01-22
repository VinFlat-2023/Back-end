using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class AreaValidator : BaseValidator, IAreaValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public AreaValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Area? obj, int? areaId)
    {
        try
        {
            if (areaId != null)
                switch (obj?.AreaId)
                {
                    case { } when obj.AreaId != areaId:
                        ValidatorResult.Failures.Add("Area id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Area is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.AreaCheck(obj.AreaId) == null)
                            ValidatorResult.Failures.Add("Area provided does not exist");
                        break;
                }

            switch (obj?.Name)
            {
                case { } when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Area name cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Area name is required");
                    break;
            }

            switch (obj?.Location)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Location):
                    ValidatorResult.Failures.Add("Location is required");
                    break;
                case { } when obj.Location.Length > 100:
                    ValidatorResult.Failures.Add("Location cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the area");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}