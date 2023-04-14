using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IEmployeeService
{
    public Task<PagedList<Employee>?> GetEmployeeList(EmployeeFilter filter, CancellationToken token);
    public Task<PagedList<Employee>?> GetEmployeeList(EmployeeFilter filter, int buildingId, CancellationToken token);
    public Task<Employee?> GetEmployeeById(int? employeeId);
    public Task<Employee?> AddEmployee(Employee employee);
    public Task<RepositoryResponse> UpdateEmployee(Employee employee);
    public Task<RepositoryResponse> UpdatePasswordEmployee(Employee employee);
    public Task<RepositoryResponse> ToggleEmployeeStatus(int employeeId);
    public Task<RepositoryResponse> DeleteEmployee(int employeeId);
    public Task<Employee?> IsEmployeeEmailExist(string? email);
    public Task<Employee?> IsEmployeeUsernameExist(string? email);
    public Task<Employee?> EmployeeLogin(string usernameOrPhoneNumber, string password);
    public Task<Employee?> GetSupervisorEmployee(int employeeId);
    public Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee);
}