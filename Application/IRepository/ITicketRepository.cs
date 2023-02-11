using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface ITicketRepository
{
    public IQueryable<Ticket> GetTicketList(TicketFilter filter);
    public IQueryable<Ticket> GetTicketDetail(int ticketId);
    public Task<Ticket> AddTicket(Ticket ticket);
    public Task<Ticket?> UpdateTicket(Ticket ticket);
    public Task<bool> DeleteTicket(int ticketId);
}