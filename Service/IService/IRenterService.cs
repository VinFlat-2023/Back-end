using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRenterService
{
    public Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, CancellationToken token);
    public Task<Renter?> GetRenterById(int? renterId);
    public Task<List<Renter>?> GetRenterListNoFilter(CancellationToken token);
    public Task<Renter?> AddRenter(Renter renter);
    public Task<Renter?> UpdateRenter(Renter renter);
    public Task<bool> ToggleRenterStatus(int renterId);
    public Task<bool> DeleteRenter(int renterId);
    public Task<Renter> Login(string username, string password);
    public Task<Renter?> RenterLogin(string username, string password);
    public Task<Renter?> GetRenterByUsername(string username);
    public Task<Renter?> RenterUsernameCheck(string? userName);
    public Task<Renter?> RenterEmailCheck(string? email);
}