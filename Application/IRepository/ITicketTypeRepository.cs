using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface ITicketTypeRepository
{
    public IQueryable<TicketType> GetTicketTypeList(TicketTypeFilter filter);
    public IQueryable<TicketType> GetTicketTypeDetail(int? ticketTypeId);
    public Task<TicketType> AddTicketType(TicketType ticketType);
    public Task<RepositoryResponse> UpdateTicketType(TicketType ticketType);
    public Task<RepositoryResponse> DeleteTicketType(int ticketTypeId);
    public Task<RepositoryResponse> ToggleTicketTypeStatus(int ticketTypeId);
}