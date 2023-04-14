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

    public IQueryable<Employee> IsEmployeeEmailExist(string? email)
    {
        return _context.Employees
            .Where(x => x.Email.ToLower().Equals(email.ToLower()));
    }

    public IQueryable<Employee> IsEmployeeUsernameExist(string? username)
    {
        return _context.Employees
            .Where(x => x.Username.ToLower().Equals(username.ToLower()));
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
    public async Task<Employee?> AddEmployee(Employee employee)
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
        var employeeData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (employeeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };
        
        employeeData.Email = employee.Email;
        employeeData.Phone = employee.Phone;
        employeeData.Address = employee.Address;
        employeeData.FullName = employee.FullName;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Employee updated successfully"
        };
    }

    public async Task<RepositoryResponse> UpdateEmployeePassword(Employee employee)
    {
        var employeeData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (employeeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        employeeData.Password = employee.Password;

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
        var employeeFound = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (employeeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        employeeFound.Status = !employeeFound.Status;

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
        var employeeFound = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId);

        if (employeeFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Employee not found"
            };

        _context.Employees.Remove(employeeFound);

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
    /// <param name="usernameOrPhoneNumber"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public IQueryable<Employee> GetEmployee(string usernameOrPhoneNumber, string password)
    {
        return _context.Employees
            .Include(b => b.Role)
            .Where(a => (a.Username == usernameOrPhoneNumber || a.Phone == usernameOrPhoneNumber)
                        && a.Password == password);
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