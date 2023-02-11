using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class MajorValidator : BaseValidator, IMajorValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public MajorValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Major? obj, int? majorId)
    {
        try
        {
            if (majorId != null)
                switch (obj?.MajorId)
                {
                    case { } when obj.MajorId != majorId:
                        ValidatorResult.Failures.Add("Major id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Major is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.MajorCheck(obj.MajorId) == null)
                            ValidatorResult.Failures.Add("Major provided does not exist");
                        break;
                }

            switch (obj?.UniversityId)
            {
                case null:
                    ValidatorResult.Failures.Add("University is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.UniversityCheck(obj.UniversityId) == null)
                        ValidatorResult.Failures.Add("University provided does not exist");
                    break;
            }

            switch (obj?.Name)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Major name is required");
                    break;
                case { } when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("Major name cannot exceed 100 characters");
                    break;
                case { } when obj.Name.Length < 1:
                    ValidatorResult.Failures.Add("Major name must be at least 1 characters");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the major");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}