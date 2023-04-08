using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface ITicketRepository
{
    public IQueryable<Ticket> GetTicketList(TicketFilter filter);
    public IQueryable<Ticket> GetTicketList(TicketFilter filters, int id, bool isManagement);
    public IQueryable<Ticket> GetTicketDetail(int? ticketId);
    public IQueryable<Ticket> GetTicketDetail(int? ticketId, int? renterId);
    public Task<Ticket> CreateTicket(Ticket ticket);
    public Task<RepositoryResponse> UpdateTicket(Ticket ticket);
    public Task<RepositoryResponse> DeleteTicket(int ticketId);
    public Task<RepositoryResponse> UpdateTicketImage(Ticket ticket, int number);
}