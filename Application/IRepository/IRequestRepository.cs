using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRequestRepository
{
    public IQueryable<Request> GetRequestList(RequestFilter filter);
    public IQueryable<Request> GetRequestDetail(int requestId);
    public Task<Request> AddRequest(Request request);
    public Task<Request?> UpdateRequest(Request request);
    public Task<bool> DeleteRequest(int requestId);
}