using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class EmployeeService : IEmployeeService
{
    private readonly string _cacheKey = "employee";
    private readonly string _cacheKeyPageNumber = "page-number-employee";
    private readonly string _cacheKeyPageSize = "page-size-employee";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public EmployeeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Employee>?> GetEmployeeList(EmployeeFilter filters, CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;
        /*
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Employee>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                var matches = cacheDataList.Where(x =>
                    (filters.Username == null ||
                     x.Username.Contains(filters.Username))
                    && (filters.Status == null || x.Status == filters.Status)
                    && (filters.RoleName == null || x.Role.RoleName.ToLower().Contains(filters.RoleName.ToLower()))
                    && (filters.FullName == null || x.FullName.ToLower().Contains(filters.FullName.ToLower()))
                    && (filters.PhoneNumber == null || x.PhoneNumber.Contains(filters.PhoneNumber))
                    && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }
        */
        var queryable = _repositoryWrapper.Employees.GetEmployeeList(filters);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Employee>.Create(queryable, pageNumber, pageSize, token);

        /*
        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        */

        return pagedList;
    }

    public async Task<Employee?> GetEmployeeById(int? employeeId, CancellationToken token)
    {
        return await _repositoryWrapper.Employees.GetEmployeeById(employeeId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Employee?> GetSupervisorEmployee(int employeeId, CancellationToken token)
    {
        return await _repositoryWrapper.Employees.GetEmployeeById(employeeId)
            .Where(x => x.Role.RoleName == "Supervisor")
            .FirstOrDefaultAsync(token);
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
        return await _repositoryWrapper.Employees.UpdateEmployee(employee);
    }

    public async Task<RepositoryResponse> UpdateEmployeeBuilding(Employee employee)
    {
        return await _repositoryWrapper.Employees.UpdateEmployeeBuilding(employee);
    }

    public async Task<RepositoryResponse> UpdateEmployeeManagement(Employee employee)
    {
        return await _repositoryWrapper.Employees.UpdateEmployeeManagement(employee);
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

    public async Task<RepositoryResponse> IsEmployeeEmailExist(string? email, int? employeeId, CancellationToken token)
    {
        return await _repositoryWrapper.Employees.IsEmployeeEmailExist(email, employeeId, token);
    }


    public async Task<RepositoryResponse> IsEmployeeEmailExist(string? email, CancellationToken token)
    {
        return await _repositoryWrapper.Employees.IsEmployeeEmailExist(email, token);
    }

    public async Task<RepositoryResponse> IsEmployeeUsernameExist(string? username, CancellationToken token)
    {
        return await _repositoryWrapper.Employees.IsEmployeeUsernameExist(username, token);
    }

    public async Task<Employee?> EmployeeLogin(string usernameOrPhoneNumber, string password, CancellationToken token)
    {
        return await _repositoryWrapper.Employees.EmployeeLogin(usernameOrPhoneNumber, password, token);
    }
}