using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class RequestRepository : IRequestRepository
{
    private readonly ApplicationContext _context;

    public RequestRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all requests
    /// </summary>
    /// <returns></returns>
    public IQueryable<Request> GetRequestList(RequestFilter filters)
    {
        return _context.Requests
            .Include(x => x.RequestType)
            .Where(x => x.RequestTypeId == x.RequestType.RequestTypeId)
            // Filter starts here
            .Where(x =>
                (filters.RequestName == null || x.RequestName.Contains(filters.RequestName))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.RequestTypeId == null || x.RequestTypeId == filters.RequestTypeId)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get request by id
    /// </summary>
    /// <param name="requestId"></param>
    /// <returns></returns>
    public IQueryable<Request> GetRequestDetail(int requestId)
    {
        return _context.Requests
            .Where(x => x.RequestId == requestId);
    }

    /// <summary>
    ///     AddFeedback new request to database
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<Request> AddRequest(Request request)
    {
        await _context.Requests.AddAsync(request);
        await _context.SaveChangesAsync();
        return request;
    }

    /// <summary>
    ///     UpdateFeedback request by id
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<Request?> UpdateRequest(Request? request)
    {
        var requestData = await _context.Requests
            .FirstOrDefaultAsync(x => x.RequestId == request!.RequestId);
        if (requestData == null)
            return null;

        requestData.Description = request?.Description ?? requestData.Description;
        requestData.SolveDate = request?.SolveDate ?? requestData.SolveDate;
        requestData.RequestTypeId = request?.RequestTypeId ?? requestData.RequestTypeId;

        await _context.SaveChangesAsync();
        return requestData;
    }

    /// <summary>
    ///     DeleteFeedback request by id
    /// </summary>
    /// <param name="requestId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteRequest(int requestId)
    {
        var requestFound = await _context.Requests
            .FirstOrDefaultAsync(x => x.RequestId == requestId);
        if (requestFound == null)
            return false;
        _context.Requests.Remove(requestFound);
        await _context.SaveChangesAsync();
        return true;
    }
}