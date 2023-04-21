using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface ITicketService
{
    public Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, CancellationToken token);

    public Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, int userId, bool isManagement,
        CancellationToken token);

    public Task<RepositoryResponse> UpdateTicketImage(Ticket ticket, int number);
    public Task<Ticket?> GetTicketById(int? ticketId, CancellationToken token);
    public Task<Ticket?> GetTicketById(int? ticketId, int? renterId, CancellationToken cancellationToken);
    public Task<Ticket?> AddTicket(Ticket ticket);
    public Task<RepositoryResponse> UpdateTicket(Ticket ticket);
    public Task<RepositoryResponse> DeleteTicket(int ticketId);
}