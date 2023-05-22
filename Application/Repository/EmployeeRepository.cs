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
                && (filters.PhoneNumber == null || x.PhoneNumber.Contains(filters.PhoneNumber)))
            .AsNoTracking();
    }

    public IQueryable<Employee> GetEmployeeList(EmployeeFilter filters, int buildingId)
    {
        throw new NotImplementedException();
    }

    public async Task<RepositoryResponse> IsEmployeeEmailExist(string? email, CancellationToken token)
    {
        if (email == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Địa chỉ email không được để trống"
            };

        if (await _context.Employees
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()), token) == null)

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Địa chỉ email này chưa được sử dụng"
            };

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Địa chỉ email này đã tồn tại"
        };
    }

    public async Task<RepositoryResponse> IsEmployeeEmailExist(string? email, int? employeeId, CancellationToken token)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId, token);

        if (employee == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không tìm thấy tài khoản này"
            };

        if (email == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Địa chỉ email không được để trống"
            };

        if (email.ToLower().Equals(employee.Email.ToLower()))
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Địa chỉ email này thuộc tài khoản này"
            };

        if (await _context.Employees
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()), token) == null)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Địa chỉ email này chưa được sử dụng"
            };

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Địa chỉ email này đã tồn tại"
        };
    }

    public async Task<RepositoryResponse> IsEmployeeUsernameExist(string? username, CancellationToken token)
    {
        var employee = await _context.Employees
            .Where(x => x.Username.ToLower().Equals(username.ToLower()))
            .FirstOrDefaultAsync(token);

        if (employee == null)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tên đăng nhập này chưa được sử dụng"
            };

        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Tên đăng nhập này đã tồn tại"
        };
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
                Message = "Nhân viên không tồn tại"
            };

        employeeData.Email = employee.Email;
        employeeData.PhoneNumber = employee.PhoneNumber;
        employeeData.Address = employee.Address;
        employeeData.FullName = employee.FullName;
        
        _context.Attach(employeeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Thông tin của nhân viên đã được cập nhật thành công"
        };
    }

    public async Task<RepositoryResponse> UpdateEmployeeManagement(Employee employee)
    {
        var employeeData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (employeeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Nhân viên không tồn tại"
            };

        employeeData.SupervisorBuildingId = employee.SupervisorBuildingId;
        
        _context.Attach(employeeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Thông tin của nhân viên đã được cập nhật thành công"
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
                Message = "Nhân viên không tồn tại"
            };

        employeeData.Password = employee.Password;
        
        _context.Attach(employeeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Mật khẩu đã được cập nhật"
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
                Message = "Nhân viên không tồn tại"
            };

        employeeFound.Status = !employeeFound.Status;
        
        _context.Attach(employeeFound).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Trạng thái của nhân viên đã được cập nhật"
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
                Message = "Nhân viên không tồn tại"
            };

        _context.Employees.Remove(employeeFound);

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Nhân viên đã được xoá"
        };
    }

    /// <summary>
    ///     Get employee based on username and password
    /// </summary>
    /// <param name="usernameOrPhoneNumber"></param>
    /// <param name="password"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<Employee?> GetEmployee(string usernameOrPhoneNumber, string password,
        CancellationToken token)
    {
        return await _context.Employees
            .Include(b => b.Role)
            .FirstOrDefaultAsync(a => (a.Username == usernameOrPhoneNumber || a.PhoneNumber == usernameOrPhoneNumber)
                                      && a.Password == password, token);
    }

    public async Task<Employee?> GetEmployeeByUserName(string userName, CancellationToken token)
    {
        return await _context.Employees
            .Where(a => a.Username == userName)
            .Include(b => b.Role).FirstOrDefaultAsync(token);
    }

    public async Task<RepositoryResponse> UpdateEmployeeProfilePicture(Employee employee)
    {
        var employeeData = await _context.Employees
            .FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

        if (employeeData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Nhân viên không tồn tại"
            };

        employeeData.EmployeeImageUrl = employee.EmployeeImageUrl;
        
        _context.Attach(employeeData).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Thông tin nhân viên đã được cập nhật"
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