using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRenterRepository
{
    public IQueryable<Renter> GetRenterList(RenterFilter filter);
    public IQueryable<Renter> GetRenterListNoFilter();
    public IQueryable<Renter> GetRenterDetail(int? renterId);
    public Task<Renter?> AddRenter(Renter renter);
    public Task<Renter?> UpdateRenter(Renter renter);
    public Task<bool> ToggleRenter(int renterId);
    public Task<bool> DeleteRenter(int renterId);
    public IQueryable<Renter?> GetRenter(string username, string password);
    public IQueryable<Renter> GetRenterByUsername(string username);
    public Task<Renter?> RenterEmailCheck(string? email);
    public Task<Renter?> RenterUsernameCheck(string? username);
    public Task<Renter?> GetARenterByUserName(string username);
    public IEnumerable<Renter> GetRenterWithActiveContract();
    public IQueryable<Renter> GetRenterDetailWithContractId(int userId);
}