using Domain.EntityRequest.Employee;
using Domain.EntityRequest.Renter;
using Service.Validator;

namespace Service.IValidator;

public interface IPasswordValidator
{
    public Task<ValidatorResult> ValidateParams(RenterUpdatePasswordRequest? renter, int? renterId,
        CancellationToken token);

    public Task<ValidatorResult> ValidateParams(EmployeeUpdatePasswordRequest? employee, int? employeeId,
        CancellationToken token);
}