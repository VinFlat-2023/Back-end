using Domain.EntityRequest.Employee;
using Service.Validator;

namespace Service.IValidator;

public interface IEmployeeValidator
{
    Task<ValidatorResult> ValidateParams(EmployeeUpdateRequest? obj, int? employeeId, CancellationToken token);

    Task<ValidatorResult> ValidateParams(EmployeeCreateRequest? obj, CancellationToken token);
}