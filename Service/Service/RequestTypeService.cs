using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RequestTypeService : IRequestTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RequestTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<RequestType>?> GetRequestTypeList(RequestTypeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.RequestTypes.GetRequestTypeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<RequestType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<RequestType?> GetRequestTypeById(int? requestTypeId)
    {
        return await _repositoryWrapper.RequestTypes.GetRequestTypeDetail(requestTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<RequestType?> AddRequestType(RequestType requestType)
    {
        return await _repositoryWrapper.RequestTypes.AddRequestType(requestType);
    }

    public async Task<RequestType?> UpdateRequestType(RequestType requestType)
    {
        return await _repositoryWrapper.RequestTypes.UpdateRequestType(requestType);
    }

    public async Task<bool> DeleteRequestType(int requestTypeId)
    {
        return await _repositoryWrapper.RequestTypes.DeleteRequestType(requestTypeId);
    }
}