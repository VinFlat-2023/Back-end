using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RenterService : IRenterService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RenterService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Renter>?> GetRenterList(RenterFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Renters.GetRenterList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Renter>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<List<Renter>?> GetRenterListBasedOnFlat(int flatId, CancellationToken token)
    {
        return await _repositoryWrapper.Renters.GetRenterListBasedOnFlat(flatId)
            .ToListAsync(token);
    }

    public async Task<Renter?> GetRenterById(int? renterId)
    {
        return await _repositoryWrapper.Renters.GetRenterDetail(renterId)
            .FirstOrDefaultAsync();
    }

    public async Task<Renter?> GetRenterByUsername(string username)
    {
        return await _repositoryWrapper.Renters.GetRenterByUsername(username).FirstOrDefaultAsync();
    }

    public async Task<Renter?> RenterUsernameCheck(string? username)
    {
        return await _repositoryWrapper.Renters.RenterUsernameCheck(username);
    }

    public async Task<Renter?> RenterEmailCheck(string? email)
    {
        return await _repositoryWrapper.Renters.RenterEmailCheck(email);
    }

    public async Task<Renter?> RenterDetailWithEmployeeId(int userId)
    {
        return await _repositoryWrapper.Renters.GetRenterDetailWithContractId(userId)
            .FirstOrDefaultAsync();
    }

    public async Task<Renter?> AddRenter(Renter renter)
    {
        return await _repositoryWrapper.Renters.AddRenter(renter);
    }

    public async Task<RepositoryResponse> UpdateRenter(Renter renter)
    {
        return await _repositoryWrapper.Renters.UpdateRenter(renter);
    }

    public async Task<RepositoryResponse> UpdateImageRenter(Renter renter)
    {
        return await _repositoryWrapper.Renters.UpdateImageRenter(renter);
    }

    public async Task<RepositoryResponse> ToggleRenterStatus(int renterId)
    {
        return await _repositoryWrapper.Renters.ToggleRenter(renterId);
    }

    public async Task<RepositoryResponse> DeleteRenter(int renterId)
    {
        return await _repositoryWrapper.Renters.DeleteRenter(renterId);
    }

    public async Task<Renter?> RenterLogin(string username, string password)
    {
        return await _repositoryWrapper.Renters.GetRenter(username, password)
            .FirstOrDefaultAsync();
    }
}