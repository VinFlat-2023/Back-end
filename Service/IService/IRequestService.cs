using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRequestService
{
    public Task<PagedList<Request>?> GetRequestList(RequestFilter filters, CancellationToken token);
    public Task<Request?> GetRequestById(int requestId);
    public Task<Request?> AddRequest(Request request);
    public Task<Request?> UpdateRequest(Request request);
    public Task<bool> DeleteRequest(int requestId);
}