using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface IRequestTypeRepository
{
    public IQueryable<RequestType> GetRequestTypeList(RequestTypeFilter filter);
    public IQueryable<RequestType> GetRequestTypeDetail(int? requestTypeId);
    public Task<RequestType> AddRequestType(RequestType requestType);
    public Task<RequestType?> UpdateRequestType(RequestType requestType);
    public Task<bool> DeleteRequestType(int requestTypeId);
    public Task<bool> ToggleRequestTypeStatus(int requestTypeId);
}