using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface IRequestTypeService
{
    public Task<PagedList<RequestType>?> GetRequestTypeList(RequestTypeFilter filter, CancellationToken token);
    public Task<RequestType?> GetRequestTypeById(int? requestTypeId);
    public Task<RequestType?> AddRequestType(RequestType requestType);
    public Task<RequestType?> UpdateRequestType(RequestType requestType);
    public Task<bool> DeleteRequestType(int requestTypeId);
}