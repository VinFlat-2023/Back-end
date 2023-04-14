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
    public Task<Employee?> GetEmployee(string usernameOrPhoneNumber, string password);
    public IQueryable<Employee> IsEmployeeEmailExist(string? email);
    public Task<Employee?> GetEmployeeByUserName(string userName);
    public IQueryable<Employee> IsEmployeeUsernameExist(string? username);
    public Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee);
}