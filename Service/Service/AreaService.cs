using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class AreaService : IAreaService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public AreaService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }


    public async Task<PagedList<Area>?> GetAreaList(AreaFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Areas.GetAreaList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Area>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Area?> GetAreaById(int? areaId)
    {
        return await _repositoryWrapper.Areas.GetAreaDetail(areaId);
    }

    public async Task<RepositoryResponse> AddArea(Area area)
    {
        return await _repositoryWrapper.Areas.AddArea(area);
    }

    public async Task<RepositoryResponse> UpdateArea(Area area)
    {
        return await _repositoryWrapper.Areas.UpdateArea(area);
    }

    public async Task<RepositoryResponse> DeleteArea(int areaId)
    {
        return await _repositoryWrapper.Areas.DeleteArea(areaId);
    }

    public async Task<RepositoryResponse> UpdateAreaImage(Area updateArea)
    {
        return await _repositoryWrapper.Areas.UpdateAreaImage(updateArea);
    }

    public async Task<RepositoryResponse> ToggleAreaStatus(int areaId)
    {
        return await _repositoryWrapper.Areas.ToggleArea(areaId);
    }
}