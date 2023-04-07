using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationContext _context;

    public EmployeeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get list of all employee available in the database
    /// </summary>
    /// <returns></returns>
    public IQueryable<Employee> GetEmployeeList(EmployeeFilter filters)
    {
        return _context.Employees
            .Include(x => x.Role)
            // Filter starts here
            .Where(x =>
                (filters.Username == null ||
                 x.Username.Contains(filters.Username))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.RoleName == null || x.Role.RoleName.ToLower().Contains(filters.RoleName.ToLower()))
                && (filters.FullName == null || x.FullName.ToLower().Contains(filters.FullName.ToLower()))
                && (filters.Phone == null || x.Phone.Contains(filters.Phone)))
            .AsNoTracking();
    }

    public async Task<Employee?> IsEmployeeEmailExist(string email)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    public async Task<Employee?> IsEmployeeUsernameExist(string username)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
    }

    /// <summary>
    ///     Get employee details by Id
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    public IQueryable<Employee> GetEmployeeDetail(int? employeeId)
    {
        return _context.Employees
            .Include(x => x.Role)
            .Where(a => a.EmployeeId == employeeId);
    }

    /// <summary>
    ///     AddExpenseHistory new employee
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public async Task<Employee> AddEmployee(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    /// <summary>
    ///     UpdateExpenseHistory employee status
    /// </summary>
    /// <param name="employee"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateEmployee(Employee employee)
    {
        var accountData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (accountData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        accountData.Email = employee.Email;
        accountData.Password = employee.Password;
        accountData.Phone = employee.Phone;
        accountData.Username = employee.Username;
        accountData.FullName = employee.FullName;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Employee updated successfully"
        };
    }

    public async Task<RepositoryResponse> UpdateEmployeePassword(Employee employee)
    {
        var accountData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (accountData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        accountData.Password = employee.Password;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Employee password updated successfully"
        };
    }

    /// <summary>
    ///     Toggle employee status
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> ToggleEmployee(int employeeId)
    {
        var accountFound = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (accountFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        accountFound.Status = !accountFound.Status;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Employee status updated successfully"
        };
    }

    /// <summary>
    ///     DeleteExpenseHistory employee by Id
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteEmployee(int employeeId)
    {
        var accountFound = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (accountFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        _context.Employees.Remove(accountFound);

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Employee deleted successfully"
        };
    }

    /// <summary>
    ///     Get employee based on username and password
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public IQueryable<Employee> GetEmployee(string username, string password)
    {
        return _context.Employees
            .Where(a => a.Username == username && a.Password == password)
            .Include(b => b.Role);
    }

    public async Task<Employee?> GetEmployeeByUserName(string userName)
    {
        return await _context.Employees
            .Where(a => a.Username == userName)
            .Include(b => b.Role).FirstOrDefaultAsync();
    }

    public async Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee)
    {
        var employeeData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (employeeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        employeeData.ImageUrl = employee.ImageUrl;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Employee profile picture updated successfully"
        };
    }

    /// <summary>
    ///     Get a list of employee containing the query string
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public IQueryable<Employee> GetEmployeeListContainName(string name)
    {
        return _context.Employees.Where(a => string.Equals(a.Username, name));
    }
}