using Domain.EntitiesForManagement;
using Domain.EntityRequest.Role;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class RoleValidator : BaseValidator, IRoleValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public RoleValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Role? obj, int? roleId, CancellationToken token)
    {
        try
        {
            if (roleId != null)
                switch (obj?.RoleId)
                {
                    case not null when obj.RoleId != roleId:
                        ValidatorResult.Failures.Add("Role id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Role is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RoleCheck(obj.RoleId, token) == null)
                            ValidatorResult.Failures.Add("Role provided does not exist");
                        break;
                }

            switch (obj?.RoleName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.RoleName):
                    ValidatorResult.Failures.Add("Role name is required");
                    break;
                case not null when obj.RoleName.Length > 100:
                    ValidatorResult.Failures.Add("Role name cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the role");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(RoleUpdateRequest? role, int? roleId, CancellationToken token)
    {
        try
        {
            if (role == null)
                ValidatorResult.Failures.Add("Role is required");
            if (roleId == null)
                ValidatorResult.Failures.Add("Role id is required");
            if (roleId != null)
                switch (roleId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Role is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.RoleCheck(roleId, token) == null)
                            ValidatorResult.Failures.Add("Role provided does not exist");
                        break;
                }

            switch (role?.RoleName)
            {
                case not null when string.IsNullOrWhiteSpace(role.RoleName):
                    ValidatorResult.Failures.Add("Role name is required");
                    break;
                case not null when role.RoleName.Length > 100:
                    ValidatorResult.Failures.Add("Role name cannot exceed 100 characters");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the role");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(RoleCreateRequest? obj, CancellationToken roleId)
    {
        try
        {
            switch (obj?.RoleName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.RoleName):
                    ValidatorResult.Failures.Add("Role name is required");
                    break;
                case not null when obj.RoleName.Length > 100:
                    ValidatorResult.Failures.Add("Role name cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the role");
            Console.WriteLine(e.Message, e.Data);
        }

        return await Task.FromResult(ValidatorResult);
    }
}