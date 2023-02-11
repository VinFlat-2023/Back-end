using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Application.IRepository;

public interface ITicketTypeRepository
{
    public IQueryable<TicketType> GetTicketTypeList(TicketTypeFilter filter);
    public IQueryable<TicketType> GetTicketTypeDetail(int? ticketTypeId);
    public Task<TicketType> AddTicketType(TicketType ticketType);
    public Task<TicketType?> UpdateTicketType(TicketType ticketType);
    public Task<bool> DeleteTicketType(int ticketTypeId);
    public Task<bool> ToggleTicketTypeStatus(int ticketTypeId);
}