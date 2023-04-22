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

    public async Task<Area?> GetAreaById(int? areaId, CancellationToken cancellationToken)
    {
        return await _repositoryWrapper.Areas.GetAreaDetail(areaId);
    }

    public async Task<RepositoryResponse> GetAreaByName(string? areaName, CancellationToken cancellationToken)
    {
        return await _repositoryWrapper.Areas.GetAreaByName(areaName, cancellationToken);
    }

    public async Task<RepositoryResponse> GetAreaByName(string? areaName, int? areaId,
        CancellationToken cancellationToken)
    {
        return await _repositoryWrapper.Areas.GetAreaByName(areaName, areaId, cancellationToken);
    }

    public async Task<Area?> AddArea(Area area)
    {
        return await _repositoryWrapper.Areas.AddArea(area);
    }

    public async Task<RepositoryResponse> UpdateArea(Area area)
    {
        try
        {
            return await _repositoryWrapper.Areas.UpdateArea(area);
        }
        catch
        {
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Area status toggled"
            };
        }
    }

    public async Task<RepositoryResponse> DeleteArea(int areaId)
    {
        try
        {
            return await _repositoryWrapper.Areas.DeleteArea(areaId);
        }
        catch
        {
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Area failed to delete"
            };
        }
    }

    public async Task<RepositoryResponse> UpdateAreaImage(Area updateArea, int number)
    {
        try
        {
            return await _repositoryWrapper.Areas.UpdateAreaImage(updateArea, number);
        }
        catch
        {
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Area image failed to upload / update"
            };
        }
    }

    public async Task<RepositoryResponse> ToggleAreaStatus(int areaId)
    {
        try
        {
            return await _repositoryWrapper.Areas.ToggleArea(areaId);
        }
        catch
        {
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Area status failed to toggle"
            };
        }
    }
}