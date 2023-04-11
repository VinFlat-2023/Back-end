using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class BuildingService : IBuildingService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public BuildingService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Building>?> GetBuildingList(BuildingFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Buildings.GetBuildingList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Building>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Building?> GetBuildingById(int? buildingId)
    {
        return await _repositoryWrapper.Buildings.GetBuildingDetail(buildingId)
            .FirstOrDefaultAsync();
    }

    public async Task<RepositoryResponse> AddBuilding(Building building)
    {
        return await _repositoryWrapper.Buildings.AddBuilding(building);
    }

    public async Task<RepositoryResponse> UpdateBuilding(Building building)
    {
        return await _repositoryWrapper.Buildings.UpdateBuilding(building);
    }

    public async Task<RepositoryResponse> UpdateBuildingImages(Building building, int number)
    {
        return await _repositoryWrapper.Buildings.UpdateBuildingImages(building, number);
    }

    public async Task<RepositoryResponse> DeleteBuilding(int buildingId)
    {
        return await _repositoryWrapper.Buildings.DeleteBuilding(buildingId);
    }
}