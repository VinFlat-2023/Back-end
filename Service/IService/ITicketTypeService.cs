using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;

namespace Service.IService;

public interface ITicketTypeService
{
    public Task<PagedList<TicketType>?> GetTicketTypeList(TicketTypeFilter filter, CancellationToken token);
    public Task<TicketType?> GetTicketTypeById(int? ticketTypeId, CancellationToken cancellationToken);
    public Task<TicketType?> AddTicketType(TicketType ticketType);
    public Task<RepositoryResponse> UpdateTicketType(TicketType ticketType);
    public Task<RepositoryResponse> DeleteTicketType(int ticketTypeId);
}