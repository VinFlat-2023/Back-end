using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IEmployeeRepository
{
    public IQueryable<Employee> GetEmployeeList(EmployeeFilter filters);
    public IQueryable<Employee> GetEmployeeList(EmployeeFilter filters, int buildingId);
    public IQueryable<Employee> GetEmployeeDetail(int? employeeId);
    public Task<Employee?> AddEmployee(Employee employee);
    public Task<RepositoryResponse> UpdateEmployee(Employee employee);
    public Task<RepositoryResponse> UpdateEmployeePassword(Employee employee);
    public Task<RepositoryResponse> ToggleEmployee(int employeeId);
    public Task<RepositoryResponse> DeleteEmployee(int employeeId);

    public Task<Employee?> GetEmployee(string usernameOrPhoneNumber, string password,
        CancellationToken cancellationToken);

    public Task<RepositoryResponse> IsEmployeeEmailExist(string? email, CancellationToken token);
    public Task<RepositoryResponse> IsEmployeeEmailExist(string? email, int? employeeId, CancellationToken token);
    public Task<Employee?> GetEmployeeByUserName(string userName, CancellationToken token);
    public Task<RepositoryResponse> IsEmployeeUsernameExist(string? username, CancellationToken token);
    public Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee);
}