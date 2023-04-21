using Domain.EntitiesForManagement;
using Domain.EntityRequest.Role;
using Service.Validator;

namespace Service.IValidator;

public interface IRoleValidator
{
    Task<ValidatorResult> ValidateParams(Role? obj, int? roleId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(RoleUpdateRequest? role, int? roleId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(RoleCreateRequest? role, CancellationToken roleId);
}