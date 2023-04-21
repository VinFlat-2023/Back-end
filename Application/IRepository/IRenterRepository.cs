using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRenterRepository
{
    public IQueryable<Renter> GetRenterList(RenterFilter filter);
    public IQueryable<Renter> GetRenterListBasedOnFlat(int flatId);
    public IQueryable<Renter> GetRenterDetail(int? renterId);
    public Task<Renter> AddRenter(Renter renter);
    public Task<RepositoryResponse> UpdateRenter(Renter renter);
    public Task<RepositoryResponse> UpdateImageRenter(Renter renter);
    public Task<RepositoryResponse> UpdatePasswordRenter(Renter renter);
    public Task<RepositoryResponse> ToggleRenter(int renterId);
    public Task<RepositoryResponse> DeleteRenter(int renterId);
    public Task<Renter?> GetRenter(string usernameOrPhoneNumber, string password, CancellationToken token);
    public IQueryable<Renter> GetRenterByUsername(string username);
    public Task<RepositoryResponse> IsRenterEmailExist(string? email, CancellationToken token);
    public Task<RepositoryResponse> IsRenterEmailExist(string? email, int? renterId, CancellationToken token);
    public Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token);
    public Task<Renter?> GetARenterByUserName(string username);
    public IEnumerable<Renter> GetRenterWithActiveContract();
    public IQueryable<Renter> GetRenterDetailWithContractId(int userId);
}