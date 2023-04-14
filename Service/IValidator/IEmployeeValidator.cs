using Domain.EntitiesForManagement;
using Domain.EntityRequest.Employee;
using Service.Validator;

namespace Service.IValidator;

public interface IEmployeeValidator
{
    Task<ValidatorResult> ValidateParams(Employee obj, int? employeeId);

    Task<ValidatorResult> ValidateParams(EmployeeUpdateRequest? obj, int? employeeId);

    Task<ValidatorResult> ValidateParams(EmployeeCreateRequest? obj);
}