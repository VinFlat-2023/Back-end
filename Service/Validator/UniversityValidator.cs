using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class UniversityValidator : BaseValidator, IUniversityValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public UniversityValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(University? obj, int? universityId)
    {
        try
        {
            if (universityId != null)
                switch (obj?.UniversityId)
                {
                    case { } when obj.UniversityId != universityId:
                        ValidatorResult.Failures.Add("University id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("University is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.UniversityCheck(obj.UniversityId) == null)
                            ValidatorResult.Failures.Add("University provided does not exist");
                        break;
                }

            switch (obj?.UniversityName)
            {
                case { } when obj.UniversityName.Length > 100:
                    ValidatorResult.Failures.Add("University name cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.UniversityName):
                    ValidatorResult.Failures.Add("University name is required");
                    break;
            }

            switch (obj?.Address)
            {
                case { } when obj.Address.Length > 100:
                    ValidatorResult.Failures.Add("Address cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Address):
                    ValidatorResult.Failures.Add("University address is required");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the university");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}