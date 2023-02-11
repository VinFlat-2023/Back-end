using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class TicketTypeService : ITicketTypeService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public TicketTypeService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<TicketType>?> GetTicketTypeList(TicketTypeFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.TicketTypes.GetTicketTypeList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<TicketType>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<TicketType?> GetTicketTypeById(int? ticketTypeId)
    {
        return await _repositoryWrapper.TicketTypes.GetTicketTypeDetail(ticketTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<TicketType?> AddTicketType(TicketType ticketType)
    {
        return await _repositoryWrapper.TicketTypes.AddTicketType(ticketType);
    }

    public async Task<TicketType?> UpdateTicketType(TicketType ticketType)
    {
        return await _repositoryWrapper.TicketTypes.UpdateTicketType(ticketType);
    }

    public async Task<bool> DeleteTicketType(int ticketTypeId)
    {
        return await _repositoryWrapper.TicketTypes.DeleteTicketType(ticketTypeId);
    }
}