using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface ITicketTypeService
{
    public Task<PagedList<TicketType>?> GetTicketTypeList(TicketTypeFilter filter, CancellationToken token);
    public Task<TicketType?> GetTicketTypeById(int? ticketTypeId);
    public Task<TicketType?> AddTicketType(TicketType ticketType);
    public Task<TicketType?> UpdateTicketType(TicketType ticketType);
    public Task<bool> DeleteTicketType(int ticketTypeId);
}