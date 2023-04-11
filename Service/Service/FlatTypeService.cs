using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class FlatTypeService : IFlatTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public FlatTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<FlatType>?> GetFlatTypeList(FlatTypeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.FlatTypes.GetFlatTypeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<FlatType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<FlatType?> GetFlatTypeById(int? flatTypeId)
    {
        return await _repositoryWrapper.FlatTypes.GetFlatTypeDetail(flatTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<FlatType?> AddFlatType(FlatType flatType)
    {
        return await _repositoryWrapper.FlatTypes.AddFlatType(flatType);
    }

    public async Task<RepositoryResponse> UpdateFlatType(FlatType flatType)
    {
        return await _repositoryWrapper.FlatTypes.UpdateFlatType(flatType);
    }

    public async Task<RepositoryResponse> DeleteFlatType(int flatTypeId)
    {
        return await _repositoryWrapper.FlatTypes.DeleteFlatType(flatTypeId);
    }
}