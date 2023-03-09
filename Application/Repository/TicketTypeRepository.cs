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
    ///     Get all ticketFilterRequest types
    /// </summary>
    /// <returns></returns>
    public IQueryable<TicketType> GetTicketTypeList(TicketTypeFilter filters)
    {
        return _context.TicketTypes
            .Where(x =>
                (filters.Name == null || x.TicketTypeName.Contains(filters.Name))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get TicketType by Id
    /// </summary>
    /// <param name="ticketTypeId"></param>
    /// <returns></returns>
    public IQueryable<TicketType> GetTicketTypeDetail(int? ticketTypeId)
    {
        return _context.TicketTypes
            .Where(x => x.TicketTypeId == ticketTypeId);
    }

    /// <summary>
    ///     AddFeedback new ticketFilterRequest type
    /// </summary>
    /// <param name="ticketType"></param>
    /// <returns></returns>
    public async Task<TicketType> AddTicketType(TicketType ticketType)
    {
        await _context.TicketTypes.AddAsync(ticketType);
        await _context.SaveChangesAsync();
        return ticketType;
    }

    /// <summary>
    ///     UpdateFeedback TicketType
    /// </summary>
    /// <param name="ticketType"></param>
    /// <returns></returns>
    public async Task<TicketType?> UpdateTicketType(TicketType? ticketType)
    {
        var requestTypeData = await _context.TicketTypes
            .FirstOrDefaultAsync(x => x.TicketTypeId == ticketType!.TicketTypeId);
        if (requestTypeData == null)
            return null;

        requestTypeData.Description = ticketType?.Description ?? requestTypeData.Description;
        requestTypeData.TicketTypeName = ticketType?.TicketTypeName ?? requestTypeData.TicketTypeName;
        requestTypeData.Status = ticketType?.Status ?? requestTypeData.Status;

        await _context.SaveChangesAsync();

        return requestTypeData;
    }

    /// <summary>
    ///     DeleteFeedback TicketType
    /// </summary>
    /// <param name="ticketTypeId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteTicketType(int ticketTypeId)
    {
        var ticketTypeFound = await _context.TicketTypes
            .FirstOrDefaultAsync(x => x.TicketTypeId == ticketTypeId);
        if (ticketTypeFound == null)
            return false;
        _context.TicketTypes.Remove(ticketTypeFound);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Toggle TicketType status by Id
    /// </summary>
    /// <param name="ticketTypeId"></param>
    /// <returns></returns>
    public async Task<bool> ToggleTicketTypeStatus(int ticketTypeId)
    {
        var ticketTypeStatus = await _context.TicketTypes
            .FirstOrDefaultAsync(x => x.TicketTypeId == ticketTypeId);

        if (ticketTypeStatus == null)
            return false;

        ticketTypeStatus.Status = !ticketTypeStatus.Status;

        await _context.SaveChangesAsync();
        return true;
    }
}