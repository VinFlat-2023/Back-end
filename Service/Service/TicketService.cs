using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class TicketService : ITicketService
{
    private readonly string _cacheKey = "ticket";
    private readonly string _cacheKeyPageNumber = "page-number-ticket";
    private readonly string _cacheKeyPageSize = "page-size-ticket";
    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public TicketService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, CancellationToken token)
    {
        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Ticket>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);

        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
            else
            {
                var matches =
                    cacheDataList.Where(x =>
                        (filters.Status == null || x.Status == filters.Status)
                        && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                        && (filters.TicketId == null || x.TicketId == filters.TicketId)
                        && (filters.CreateDate == null || x.CreateDate == filters.CreateDate)
                        && (filters.SolveDate == null || x.SolveDate == filters.SolveDate)
                        && (filters.Amount == null || x.TotalAmount == filters.Amount)
                        && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                        && (filters.ContractId == null || x.ContractId == filters.ContractId)
                        && (filters.EmployeeId == null || x.EmployeeId == filters.EmployeeId)
                        && (filters.Description == null || x.Description.Contains(filters.Description.ToLower()))
                        && (filters.TicketTypeName == null ||
                            x.TicketType.TicketTypeName.Contains(filters.TicketTypeName.ToLower()))
                        && (filters.ContractName == null ||
                            x.Contract.ContractName.Contains(filters.ContractName.ToLower()))
                        && (filters.TicketTypeName == null ||
                            x.TicketType.TicketTypeName.Contains(filters.TicketTypeName.ToLower()))
                        && (filters.EmployeeFullName == null ||
                            x.Employee.FullName.Contains(filters.EmployeeFullName.ToLower()))
                        && (filters.RenterId == null || x.Contract.RenterId == filters.RenterId)
                        && (filters.RenterFullname == null ||
                            x.Contract.Renter.FullName.Contains(filters.RenterFullname.ToLower()))
                        && (filters.RenterUsername == null ||
                            x.Contract.Renter.Username.Contains(filters.RenterUsername))
                        && (filters.RenterEmail == null || x.Contract.Renter.Email.Contains(filters.RenterEmail))
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize);

                if (matches.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
            }
        }

        var queryable = _repositoryWrapper.Tickets.GetTicketList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Ticket>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, int userId, bool isManagement,
        CancellationToken token)
    {
        var queryable = _repositoryWrapper.Tickets.GetTicketList(filters, userId, isManagement);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Ticket>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Ticket>?> GetTicketList(TicketFilter filters, int buildingId, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Tickets.GetTicketList(filters, buildingId);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Ticket>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<RepositoryResponse> ApproveTicket(int id, CancellationToken token)
    {
        return await _repositoryWrapper.Tickets.ApproveTicket(id, token);
    }

    public async Task<RepositoryResponse> AcceptTicket(int ticketId, int userId, CancellationToken token)
    {
        return await _repositoryWrapper.Tickets.AcceptTicket(ticketId, userId, token);
    }

    public async Task<RepositoryResponse> SolveTicket(int ticketId, CancellationToken token)
    {
        return await _repositoryWrapper.Tickets.SolveTicket(ticketId, token);
    }

    public async Task<RepositoryResponse> UpdateTicketStatus(Ticket updateTicket, CancellationToken token)
    {
        return await _repositoryWrapper.Tickets.UpdateTicketStatus(updateTicket, token);
    }

    public async Task<RepositoryResponse> MoveTicketToCancelled(int ticketId,
        CancellationToken cancellationToken)
    {
        return await _repositoryWrapper.Tickets.MoveTicketToCancelled(ticketId, cancellationToken);
    }

    public async Task<Ticket?> GetTicketById(int? ticketId, CancellationToken token)
    {
        return await _repositoryWrapper.Tickets.GetTicketDetail(ticketId)
            .FirstOrDefaultAsync(token);
    }

    public async Task<Ticket?> GetTicketById(int? ticketId, int? renterId, CancellationToken token)
    {
        return await _repositoryWrapper.Tickets.GetTicketDetail(ticketId, renterId)
            .FirstOrDefaultAsync(token);
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

    public async Task<RepositoryResponse> UpdateTicketImage(Ticket ticket, int number)
    {
        return await _repositoryWrapper.Tickets.UpdateTicketImage(ticket, number);
    }
}