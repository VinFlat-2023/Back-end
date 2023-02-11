using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface ITicketService
{
    public Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, CancellationToken token);
    public Task<Ticket?> GetTicketById(int ticketId);
    public Task<Ticket?> AddTicket(Ticket ticket);
    public Task<Ticket?> UpdateTicket(Ticket ticket);
    public Task<bool> DeleteTicket(int ticketId);
}