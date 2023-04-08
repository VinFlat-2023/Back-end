using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IEmployeeValidator
{
    Task<ValidatorResult> ValidateParams(Employee obj, int? employeeId, bool isUpdate);
}