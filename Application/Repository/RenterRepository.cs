using Application.IRepository;
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

    public IQueryable<Renter> GetRenterList(RenterFilter filters)
    {
        return _context.Renters
            .Include(x => x.University)
            .ThenInclude(x => x.Majors)
            .Include(x => x.Major)
            .Where(x => x.MajorId == x.Major.MajorId)
            .Where(x => x.UniversityId == x.University.UniversityId)
            // Filter starts here
            .Where(x =>
                (filters.Username == null || x.Username.Contains(filters.Username))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Address == null || x.Address.Contains(filters.Address))
                && (filters.Phone == null || x.Phone.Contains(filters.Phone))
                && (filters.Email == null || x.Email.Contains(filters.Email))
                && (filters.UniversityId == null || x.UniversityId == filters.UniversityId)
                && (filters.MajorId == null || x.MajorId == filters.MajorId)
                && (filters.Gender == null || x.Gender == filters.Gender)
                && (filters.FullName == null || x.FullName.Contains(filters.FullName)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get a list of all renters
    /// </summary>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterListNoFilter()
    {
        return _context.Renters
            .Include(x => x.University)
            .ThenInclude(x => x.Majors)
            .Include(x => x.Major)
            .Where(x => x.MajorId == x.Major.MajorId);
    }

    /// <summary>
    ///     Get a renter detail by Id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public IQueryable<Renter> GetRenterDetail(int? userId)
    {
        return _context.Renters
            .Include(x => x.University)
            .ThenInclude(x => x.Majors)
            .Include(x => x.Major)
            .Include(x => x.Contracts
                .Where(y => y.ContractStatus == "Active"))
            .Where(x => x.MajorId == x.Major.MajorId)
            .Where(x => x.UniversityId == x.University.UniversityId)
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
    public async Task<Renter?> AddRenter(Renter user)
    {
        await _context.Renters.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<Renter?> RenterUsernameCheck(string? username)
    {
        return await _context.Renters
            .FirstOrDefaultAsync(x => username != null && x.Username.ToLower().Equals(username.ToLower()));
    }

    public async Task<Renter?> RenterEmailCheck(string? email)
    {
        return await _context.Renters
            .FirstOrDefaultAsync(x => email != null && x.Email.ToLower().Equals(email.ToLower()));
    }

    /// <summary>
    ///     UpdateExpenseHistory a renter
    /// </summary>
    /// <param name="renter"></param>
    /// <returns></returns>
    public async Task<Renter?> UpdateRenter(Renter? renter)
    {
        var userData = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renter!.RenterId);

        if (userData == null)
            return null;

        userData.FullName = renter?.FullName ?? userData.FullName;
        userData.Email = renter?.Email ?? userData.Email;
        userData.Password = renter?.Password ?? userData.Password;
        userData.Phone = renter?.Phone ?? userData.Phone;
        userData.MajorId = renter?.MajorId ?? userData.MajorId;
        userData.ImageUrl = renter?.ImageUrl;
        userData.Address = renter?.Address ?? userData.Address;
        userData.UniversityId = renter?.UniversityId ?? userData.UniversityId;
        userData.Gender = renter?.Gender ?? userData.Gender;
        userData.BirthDate = renter?.BirthDate ?? userData.BirthDate;

        await _context.SaveChangesAsync();

        return renter;
    }

    /// <summary>
    ///     Disable renter
    /// </summary>
    /// <param name="renterId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleRenter(int renterId)
    {
        var renterFound = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId);
        if (renterFound == null)
            return false;

        _ = renterFound.Status == !renterFound.Status;

        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Remove renter by Id
    /// </summary>
    /// <param name="renterId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRenter(int renterId)
    {
        var renterFound = await _context.Renters
            .FirstOrDefaultAsync(x => x.RenterId == renterId);

        if (renterFound == null)
            return false;

        _context.Renters.Remove(renterFound);
        await _context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    ///     Get renter based on username and passowrd
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public IQueryable<Renter?> GetRenter(string username, string password)
    {
        return _context.Renters
            .Where(a => a.Username == username && a.Password == password);
    }

    public async Task<Renter?> GetARenterByUserName(string userName)
    {
        var user = await _context.Renters.FirstOrDefaultAsync(r => r.Username == userName);
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
}