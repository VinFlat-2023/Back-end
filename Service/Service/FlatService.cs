using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class FlatService : IFlatService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Flat>?> GetFlatList(FlatFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Flats.GetFlatList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Flat>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Flat>?> GetFlatList(FlatFilter filters, int buildingId, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Flats.GetFlatList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Flat>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Flat?> GetFlatById(int? flatId, int buildingId, CancellationToken token)
    {
        return await _repositoryWrapper.Flats.GetFlatDetail(flatId, buildingId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<RepositoryResponse> AddFlat(Flat flat, List<int> roomTypeIds, CancellationToken token)
    {
        return await _repositoryWrapper.Flats.AddFlat(flat, roomTypeIds, token);
    }

    public async Task<RepositoryResponse> UpdateFlat(Flat flat)
    {
        return await _repositoryWrapper.Flats.UpdateFlat(flat);
    }

    public async Task<RepositoryResponse> DeleteFlat(int flatId)
    {
        return await _repositoryWrapper.Flats.DeleteFlat(flatId);
    }

    public async Task<RepositoryResponse> GetRoomInAFlat(int flatId, CancellationToken token)
    {
        return await _repositoryWrapper.Flats.GetRoomInAFlat(flatId, token);
    }
}