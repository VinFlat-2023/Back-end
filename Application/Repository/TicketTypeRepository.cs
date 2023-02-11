using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class TicketTypeRepository : ITicketTypeRepository
{
    private readonly ApplicationContext _context;

    public TicketTypeRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all ticket types
    /// </summary>
    /// <returns></returns>
    public IQueryable<TicketType> GetTicketTypeList(TicketTypeFilter filters)
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
    /// <param name="ticketTypeId"></param>
    /// <returns></returns>
    public IQueryable<TicketType> GetTicketTypeDetail(int? ticketTypeId)
    {
        return _context.RequestTypes
            .Where(x => x.TicketTypeId == ticketTypeId);
    }

    /// <summary>
    ///     AddFeedback new ticket type
    /// </summary>
    /// <param name="ticketType"></param>
    /// <returns></returns>
    public async Task<TicketType> AddTicketType(TicketType ticketType)
    {
        await _context.RequestTypes.AddAsync(ticketType);
        await _context.SaveChangesAsync();
        return ticketType;
    }

    /// <summary>
    ///     UpdateFeedback RequestType
    /// </summary>
    /// <param name="ticketType"></param>
    /// <returns></returns>
    public async Task<TicketType?> UpdateTicketType(TicketType? ticketType)
    {
        var ticketTypeData = await _context.RequestTypes
            .FirstOrDefaultAsync(x => x.TicketTypeId == ticketType!.TicketTypeId);
        if (ticketTypeData == null)
            return null;

        ticketTypeData.Description = ticketType?.Description ?? ticketTypeData.Description;
        ticketTypeData.Name = ticketType?.Name ?? ticketTypeData.Name;
        ticketTypeData.Status = ticketType?.Status ?? ticketTypeData.Status;

        await _context.SaveChangesAsync();

        return ticketTypeData;
    }

    /// <summary>
    ///     DeleteFeedback RequestType
    /// </summary>
    /// <param name="requestTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteTicketType(int requestTypeId)
    {
        var requestTypeFound = await _context.RequestTypes
            .FirstOrDefaultAsync(x => x.TicketTypeId == requestTypeId);
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
    public async Task<bool> ToggleTicketTypeStatus(int requestTypeId)
    {
        var requestTypeStatus = await _context.RequestTypes
            .FirstOrDefaultAsync(x => x.TicketTypeId == requestTypeId);
        if (requestTypeStatus == null)
            return false;
        _context.RequestTypes.Remove(requestTypeStatus);
        await _context.SaveChangesAsync();
        return true;
    }
}