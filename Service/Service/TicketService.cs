using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class TicketService : ITicketService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public TicketService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Tickets.GetTicketList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Ticket>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, int id, bool isManagement,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Tickets.GetTicketList(filters, id, isManagement);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Ticket>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<Ticket?> GetTicketById(int? ticketId)
    {
        return await _repositoryWrapper.Tickets.GetTicketDetail(ticketId)
            .FirstOrDefaultAsync();
    }

    public async Task<Ticket?> GetTicketById(int? ticketId, int? renterId)
    {
        return await _repositoryWrapper.Tickets.GetTicketDetail(ticketId, renterId)
            .FirstOrDefaultAsync();
    }

    public async Task<Ticket?> AddTicket(Ticket ticket)
    {
        return await _repositoryWrapper.Tickets.CreateTicket(ticket);
    }

    public async Task<RepositoryResponse> UpdateTicket(Ticket ticket)
    {
        return await _repositoryWrapper.Tickets.UpdateTicket(ticket);
    }

    public async Task<RepositoryResponse> DeleteTicket(int ticketId)
    {
        return await _repositoryWrapper.Tickets.DeleteTicket(ticketId);
    }
}