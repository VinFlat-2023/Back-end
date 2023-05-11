using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface ITicketRepository
{
    public IQueryable<Ticket> GetTicketList(TicketFilter filter);
    public IQueryable<Ticket> GetTicketList(TicketFilter filters, int id, bool isManagement);
    public IQueryable<Ticket> GetTicketList(TicketFilter filters, int buildingId);
    public IQueryable<Ticket> GetTicketDetail(int? ticketId);
    public IQueryable<Ticket> GetTicketDetail(int? ticketId, int? renterId);
    public Task<Ticket> CreateTicket(Ticket ticket);
    public Task<RepositoryResponse> UpdateTicket(Ticket ticket);
    public Task<RepositoryResponse> DeleteTicket(int ticketId);
    public Task<RepositoryResponse> UpdateTicketImage(Ticket ticket, int number);
    public Task<RepositoryResponse> ApproveTicket(int id, CancellationToken token);
    public Task<RepositoryResponse> AcceptTicket(int ticketId, int userId, CancellationToken token);
    public Task<RepositoryResponse> SolveTicket(int ticketId, CancellationToken token);
    public Task<RepositoryResponse> UpdateTicketStatus(Ticket updateTicket, CancellationToken token);
    public Task<RepositoryResponse> MoveTicketToCancelled(int ticketId, bool isManagement, CancellationToken token);
}