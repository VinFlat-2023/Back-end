using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class RenterRepository : IRenterRepository
{
    private readonly ApplicationContext _context;

    public RenterRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IQueryable<Renter> GetRenterList(RenterFilter filters, int buildingId)
    {
        return _context.Renters
            .Include(x => x.Contracts)
            .Where(x => x.Contracts.Any(contract => contract.BuildingId == buildingId))
            // Filter starts here
            .Where(y =>
                (filters.Username == null || y.Username.ToLower().Contains(filters.Username.ToLower()))
                && (filters.Status == null || y.Status == filters.Status)
                && (filters.Address == null || y.Address.ToLower().Contains(filters.Address.ToLower()))
                && (filters.PhoneNumber == null || y.PhoneNumber.Contains(filters.PhoneNumber))
                && (filters.Email == null || y.Email.ToLower().Contains(filters.Email.ToLower()))
                && (filters.Gender == null || y.Gender == filters.Gender)
                && (filters.FullName == null || y.FullName.ToLower().Contains(filters.FullName.ToLower())))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get a list of all renters
    /// </summary>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterListBasedOnFlat(int flatId)
    {
        return _context.Renters
            .Include(x => x.Contracts
                .Where(y => y.ContractStatus == "Active"))
            .Where(x => x.Contracts.Any(y => y.FlatId == flatId));
    }

    /// <summary>
    ///     Get a renter detail by Id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterDetail(int? userId)
    {
        return _context.Renters
            .Include(x => x.Contracts
                .Where(y => y.ContractStatus == "Active"))
            .Where(x => x.RenterId == userId);
    }

    public IQueryable<Renter> GetRenterDetailWithContractId(int userId)
    {
        return _context.Renters
            .Include(x => x.Contracts)
            .ThenInclude(x => x.Flat)
            .ThenInclude(x => x.Building)
            .Where(x => x.RenterId == userId);
    }

    /// <summary>
    ///     Get renter by username
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterByUsername(string username)
    {
        return _context.Renters
            .Where(e => e.Username == username);
    }

    /// <summary>
    ///     Create a new renter
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<Renter> AddRenter(Renter user)
    {
        await _context.Renters.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token)
    {
        var renter = await _context.Renters
            .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()), token);
        if (renter == null)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Tên đăng nhập này chưa tồn tại"
            };
        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Tên đăng nhập này đã tồn tại"
        };
    }

    public async Task<RepositoryResponse> IsRenterEmailExist(string? email, CancellationToken token)
    {
        var renter = await _context.Renters
            .Where(x => x.Email.ToLower().Equals(email.ToLower()))
            .FirstOrDefaultAsync(token);
        if (renter == null)
            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Địa chỉ email chưa tồn tại"
            };
        return new RepositoryResponse
        {
            IsSuccess = false,
            Message = "Địa chỉ email đã tồn tại"
        };
    }

    public async Task<RepositoryResponse> IsRenterEmailExist(string? email, int? renterId, CancellationToken token)
    {
        var renter = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

        if (renter == null)
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

        if (renter.Email?.Length == 0 || email.ToLower().Equals(renter.Email?.ToLower()))
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

    /// <summary>
    ///     UpdateExpenseHistory a renter
    /// </summary>
    /// <param name="renter"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateRenter(Renter renter)
    {
        var userData = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renter.RenterId);

        if (userData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "User not found"
            };

        userData.FullName = renter.FullName;
        userData.Email = renter.Email;
        userData.PhoneNumber = renter.PhoneNumber;
        userData.Address = renter.Address;
        userData.Gender = renter.Gender;
        userData.BirthDate = renter.BirthDate;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Thông tin tài khoản đã được cập nhật"
        };
    }

    public async Task<RepositoryResponse> UpdateImageRenter(Renter renter)
    {
        var userData = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renter.RenterId);

        if (userData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "User not found"
            };

        userData.ImageUrl = renter.ImageUrl;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "User image updated successful"
        };
    }

    /// <summary>
    ///     UpdateExpenseHistory a renter
    /// </summary>
    /// <param name="renter"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdatePasswordRenter(Renter renter)
    {
        var userData = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renter!.RenterId);

        if (userData == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "User not found"
            };

        userData.Password = renter.Password;

        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "User password updated successful"
        };
    }

    /// <summary>
    ///     Disable renter
    /// </summary>
    /// <param name="renterId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> ToggleRenter(int renterId)
    {
        var renterFound = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (renterFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "User not found"
            };

        _ = renterFound.Status == !renterFound.Status;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "User status updated successful"
        };
    }

    /// <summary>
    ///     Remove renter by Id
    /// </summary>
    /// <param name="renterId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteRenter(int renterId)
    {
        var renterFound = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (renterFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "User not found"
            };

        _context.Renters.Remove(renterFound);
        await _context.SaveChangesAsync();

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "User deleted"
        };
    }

    /// <summary>
    ///     Get renter based on username and passowrd
    /// </summary>
    /// <param name="usernameOrPhoneNumber"></param>
    /// <param name="password"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<Renter?> GetRenter(string usernameOrPhoneNumber, string password, CancellationToken token)
    {
        return await _context.Renters
            .FirstOrDefaultAsync(a => (a.Username == usernameOrPhoneNumber || a.PhoneNumber == usernameOrPhoneNumber)
                                      && a.Password == password, token);
    }

    public async Task<Renter?> GetARenterByUserName(string userName)
    {
        var user = await _context.Renters
            .FirstOrDefaultAsync(r => r.Username == userName);

        return user;
    }

    public IEnumerable<Renter> GetRenterWithActiveContract()
    {
        var renters = _context.Contracts
            .Include(e => e.Renter)
            .Where(e => e.ContractStatus == "Active")
            .ToList().AsQueryable()
            .Select(e => e.Renter).DistinctBy(e => e.RenterId);
        Console.WriteLine(
            $"\n\nGetRenterWithActiveContract=========\nNum of renters with contracts: {renters.Count()}");
        foreach (var renter in renters) Console.WriteLine(renter.Username);
        return renters;
    }

    public IQueryable<Renter> GetRenterList(RenterFilter filters)
    {
        return _context.Renters
            // Filter starts here
            .Where(x =>
                (filters.Username == null || x.Username.ToLower().Contains(filters.Username.ToLower()))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Address == null || x.Address.ToLower().Contains(filters.Address.ToLower()))
                && (filters.PhoneNumber == null || x.PhoneNumber.Contains(filters.PhoneNumber))
                && (filters.Email == null || x.Email.ToLower().Contains(filters.Email.ToLower()))
                && (filters.Gender == null || x.Gender == filters.Gender)
                && (filters.FullName == null || x.FullName.ToLower().Contains(filters.FullName.ToLower())))
            .AsNoTracking();
    }
}