using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRenterService
{
    public Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, CancellationToken token);
    public Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, int buildingId, CancellationToken token);
    public Task<Renter?> GetRenterById(int? renterId, CancellationToken token);
    public Task<List<Renter>?> GetRenterListBasedOnFlat(int flatId, CancellationToken token);
    public Task<Renter?> AddRenter(Renter renter);
    public Task<RepositoryResponse> UpdateRenter(Renter renter);
    public Task<RepositoryResponse> UpdateImageRenter(Renter renter);
    public Task<RepositoryResponse> ToggleRenterStatus(Renter renter);
    public Task<RepositoryResponse> DeleteRenter(int renterId);

    public Task<Renter?> RenterLogin(string usernameOrPhoneNumber, string password,
        CancellationToken token);

    public Task<Renter?> GetRenterByUsername(string username);
    public Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token);
    public Task<RepositoryResponse> IsRenterEmailExist(string? email, CancellationToken token);

    public Task<RepositoryResponse> IsRenterEmailExist(string? email, int? renterId,
        CancellationToken token);

    public Task<Renter?> RenterDetailWithEmployeeId(int userId);
    public Task<RepositoryResponse> UpdatePasswordRenter(Renter renter);
    public Task<List<Renter>?> GetRenterList(int buildingId, CancellationToken token);
}