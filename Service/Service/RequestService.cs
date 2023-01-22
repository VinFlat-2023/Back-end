using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class RequestService : IRequestService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RequestService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Request>?> GetRequestList(RequestFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Requests.GetRequestList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Request>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Request?> GetRequestById(int requestId)
    {
        return await _repositoryWrapper.Requests.GetRequestDetail(requestId)
            .FirstOrDefaultAsync();
    }

    public async Task<Request?> AddRequest(Request request)
    {
        return await _repositoryWrapper.Requests.AddRequest(request);
    }

    public async Task<Request?> UpdateRequest(Request request)
    {
        return await _repositoryWrapper.Requests.UpdateRequest(request);
    }

    public async Task<bool> DeleteRequest(int requestId)
    {
        return await _repositoryWrapper.Requests.DeleteRequest(requestId);
    }
}