using Application.IRepository;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class TicketRepository : ITicketRepository
{
    private readonly ApplicationContext _context;

    public TicketRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all tickets
    /// </summary>
    /// <returns></returns>
    public IQueryable<Ticket> GetTicketList(TicketFilter filters)
    {
        return _context.Requests
            .Include(x => x.TicketType)
            .Where(x => x.TicketTypeId == x.TicketType.TicketTypeId)
            // Filter starts here
            .Where(x =>
                (filters.TicketName == null || x.TicketName.Contains(filters.TicketName))
                && (filters.Status == null || x.Status == filters.Status)
                && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                && (filters.Description == null || x.Description.Contains(filters.Description)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get ticket by id
    /// </summary>
    /// <param name="ticketId"></param>
    /// <returns></returns>
    public IQueryable<Ticket> GetTicketDetail(int ticketId)
    {
        return _context.Requests
            .Where(x => x.TicketId == ticketId);
    }

    /// <summary>
    ///     AddFeedback new ticket to database
    /// </summary>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public async Task<Ticket> AddTicket(Ticket ticket)
    {
        await _context.Requests.AddAsync(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    /// <summary>
    ///     UpdateFeedback ticket by id
    /// </summary>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public async Task<Ticket?> UpdateTicket(Ticket? ticket)
    {
        var requestData = await _context.Requests
            .FirstOrDefaultAsync(x => x.TicketId == ticket!.TicketId);
        if (requestData == null)
            return null;

        requestData.Description = ticket?.Description ?? requestData.Description;
        requestData.SolveDate = ticket?.SolveDate ?? requestData.SolveDate;
        requestData.TicketTypeId = ticket?.TicketTypeId ?? requestData.TicketTypeId;

        await _context.SaveChangesAsync();
        return requestData;
    }

    /// <summary>
    ///     DeleteFeedback request by id
    /// </summary>
    /// <param name="requestId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteTicket(int requestId)
    {
        var requestFound = await _context.Requests
            .FirstOrDefaultAsync(x => x.TicketId == requestId);
        if (requestFound == null)
            return false;
        _context.Requests.Remove(requestFound);
        await _context.SaveChangesAsync();
        return true;
    }
}