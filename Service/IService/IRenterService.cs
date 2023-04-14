using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRenterService
{
    public Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, int buildingId, CancellationToken token);
    public Task<Renter?> GetRenterById(int? renterId);
    public Task<List<Renter>?> GetRenterListBasedOnFlat(int flatId, CancellationToken token);
    public Task<Renter?> AddRenter(Renter renter);
    public Task<RepositoryResponse> UpdateRenter(Renter renter);
    public Task<RepositoryResponse> UpdateImageRenter(Renter renter);
    public Task<RepositoryResponse> ToggleRenterStatus(int renterId);
    public Task<RepositoryResponse> DeleteRenter(int renterId);
    public Task<Renter?> RenterLogin(string usernameOrPhoneNumber, string password);
    public Task<Renter?> GetRenterByUsername(string username);
    public Task<Renter?> RenterUsernameCheck(string? username);
    public Task<Renter?> RenterEmailCheck(string? email);
    public Task<Renter?> RenterDetailWithEmployeeId(int userId);
    public Task<RepositoryResponse> UpdatePasswordRenter(Renter renter);
}