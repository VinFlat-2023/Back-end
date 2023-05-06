using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IEmployeeService
{
    public Task<PagedList<Employee>?> GetEmployeeList(EmployeeFilter filter, CancellationToken token);
    public Task<Employee?> GetEmployeeById(int? employeeId, CancellationToken token);
    public Task<Employee?> AddEmployee(Employee employee);
    public Task<RepositoryResponse> UpdateEmployee(Employee employee);
    public Task<RepositoryResponse> UpdatePasswordEmployee(Employee employee);
    public Task<RepositoryResponse> ToggleEmployeeStatus(int employeeId);
    public Task<RepositoryResponse> DeleteEmployee(int employeeId);
    public Task<RepositoryResponse> IsEmployeeEmailExist(string? email, CancellationToken token);
    public Task<RepositoryResponse> IsEmployeeEmailExist(string? objEmail, int? employeeId, CancellationToken token);
    public Task<RepositoryResponse> IsEmployeeUsernameExist(string? email, CancellationToken token);
    public Task<Employee?> EmployeeLogin(string usernameOrPhoneNumber, string password, CancellationToken token);
    public Task<Employee?> GetSupervisorEmployee(int employeeId, CancellationToken token);
    public Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee);
}