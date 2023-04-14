using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class EmployeeService : IEmployeeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public EmployeeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Employee>?> GetEmployeeList(EmployeeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Employees.GetEmployeeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Employee>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Employee>?> GetEmployeeList(EmployeeFilter filters, int buildingId,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Employees.GetEmployeeList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Employee>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Employee?> GetEmployeeById(int? employeeId)
    {
        return await _repositoryWrapper.Employees.GetEmployeeDetail(employeeId)
            .FirstOrDefaultAsync();
    }

    public async Task<Employee?> GetSupervisorEmployee(int employeeId)
    {
        return await _repositoryWrapper.Employees.GetEmployeeDetail(employeeId)
            .Where(x => x.Role.RoleName == "Supervisor")
            .FirstOrDefaultAsync();
    }

    public async Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee)
    {
        return await _repositoryWrapper.Employees.UpdateEmployeeProfilePicture(employee);
    }

    public async Task<Employee?> AddEmployee(Employee employee)
    {
        return await _repositoryWrapper.Employees.AddEmployee(employee);
    }

    public async Task<RepositoryResponse> UpdateEmployee(Employee employee)
    {
        try
        {
            return await _repositoryWrapper.Employees.UpdateEmployee(employee);
        }
        catch
        {
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee failed to update"
            };
        }
    }

    public async Task<RepositoryResponse> UpdatePasswordEmployee(Employee employee)
    {
        return await _repositoryWrapper.Employees.UpdateEmployeePassword(employee);
    }

    public async Task<RepositoryResponse> ToggleEmployeeStatus(int employeeId)
    {
        return await _repositoryWrapper.Employees.ToggleEmployee(employeeId);
    }

    public async Task<RepositoryResponse> DeleteEmployee(int employeeId)
    {
        return await _repositoryWrapper.Employees.DeleteEmployee(employeeId);
    }

    public async Task<Employee?> IsEmployeeUsernameExist(string? username)
    {
        return await _repositoryWrapper.Employees.IsEmployeeUsernameExist(username)
            .FirstOrDefaultAsync();
    }

    public async Task<Employee?> IsEmployeeEmailExist(string? email)
    {
        return await _repositoryWrapper.Employees.IsEmployeeEmailExist(email)
            .FirstOrDefaultAsync();
    }

    public async Task<Employee?> EmployeeLogin(string usernameOrPhoneNumber, string password)
    {
        return await _repositoryWrapper.Employees.GetEmployee(usernameOrPhoneNumber, password);
    }
}