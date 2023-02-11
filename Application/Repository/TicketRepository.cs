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
    ///     Get all requests
    /// </summary>
    /// <returns></returns>
    public IQueryable<Ticket> GetTicketList(TicketFilter filters)
    {
        return _context.Tickets
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
    public IQueryable<Ticket> GetTicketDetail(int? ticketId)
    {
        return _context.Tickets
            .Include(x => x.TicketType)
            .Where(x => x.TicketTypeId == x.TicketType.TicketTypeId)
            .Where(x => x.TicketId == ticketId);
    }

    /// <summary>
    ///     AddFeedback new ticket to database
    /// </summary>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public async Task<Ticket> CreateRequest(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
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
        var ticketData = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticket!.TicketId);
        if (ticketData == null)
            return null;

        ticketData.Description = ticket?.Description ?? ticketData.Description;
        ticketData.SolveDate = ticket?.SolveDate ?? ticketData.SolveDate;
        ticketData.TicketTypeId = ticket?.TicketTypeId ?? ticketData.TicketTypeId;

        await _context.SaveChangesAsync();
        return ticketData;
    }

    /// <summary>
    ///     DeleteFeedback ticket by id
    /// </summary>
    /// <param name="ticketId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteTicket(int ticketId)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticketId);
        if (ticketFound == null)
            return false;
        _context.Tickets.Remove(ticketFound);
        await _context.SaveChangesAsync();
        return true;
    }
}