using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class RequestTypeRepository : IRequestTypeRepository
{
    private readonly ApplicationContext _context;

    public RequestTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all request types
    /// </summary>
    /// <returns></returns>
    public IQueryable<RequestType> GetRequestTypeList(RequestTypeFilter filters)
    {
        return _context.RequestTypes
            .Where(x =>
                (filters.Name == null || x.Name.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get RequestType by Id
    /// </summary>
    /// <param name="requestTypeId"></param>
    /// <returns></returns>
    public IQueryable<RequestType> GetRequestTypeDetail(int? requestTypeId)
    {
        return _context.RequestTypes
            .Where(x => x.RequestTypeId == requestTypeId);
    }

    /// <summary>
    ///     AddFeedback new request type
    /// </summary>
    /// <param name="requestType"></param>
    /// <returns></returns>
    public async Task<RequestType> AddRequestType(RequestType requestType)
    {
        await _context.RequestTypes.AddAsync(requestType);
        await _context.SaveChangesAsync();
        return requestType;
    }

    /// <summary>
    ///     UpdateFeedback RequestType
    /// </summary>
    /// <param name="requestType"></param>
    /// <returns></returns>
    public async Task<RequestType?> UpdateRequestType(RequestType? requestType)
    {
        var requestTypeData = await _context.RequestTypes
            .FirstOrDefaultAsync(x => x.RequestTypeId == requestType!.RequestTypeId);
        if (requestTypeData == null)
            return null;

        requestTypeData.Description = requestType?.Description ?? requestTypeData.Description;
        requestTypeData.Name = requestType?.Name ?? requestTypeData.Name;
        requestTypeData.Status = requestType?.Status ?? requestTypeData.Status;

        await _context.SaveChangesAsync();

        return requestTypeData;
    }

    /// <summary>
    ///     DeleteFeedback RequestType
    /// </summary>
    /// <param name="requestTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRequestType(int requestTypeId)
    {
        var requestTypeFound = await _context.RequestTypes
            .FirstOrDefaultAsync(x => x.RequestTypeId == requestTypeId);
        if (requestTypeFound == null)
            return false;
        _context.RequestTypes.Remove(requestTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Toggle RequestType status by Id
    /// </summary>
    /// <param name="requestTypeId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleRequestTypeStatus(int requestTypeId)
    {
        var requestTypeStatus = await _context.RequestTypes
            .FirstOrDefaultAsync(x => x.RequestTypeId == requestTypeId);
        if (requestTypeStatus == null)
            return false;
        _context.RequestTypes.Remove(requestTypeStatus);
        await _context.SaveChangesAsync();
        return true;
    }
}