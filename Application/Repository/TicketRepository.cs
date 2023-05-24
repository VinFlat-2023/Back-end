using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

internal class TicketRepository : ITicketRepository
{
    private readonly ApplicationContext _context;

    public TicketRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all requests
    /// </summary>
    /// <returns></returns>
    public IQueryable<Ticket> GetTicketList(TicketFilter filters)
    {
        return _context.Tickets
            .Include(x => x.Employee)
            .Include(x => x.Contract)
            .Include(x => x.TicketType)
            // filter starts here
            .Where(x =>
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
                && (filters.ContractName == null || x.Contract.ContractName.Contains(filters.ContractName.ToLower()))
                && (filters.TicketTypeName == null ||
                    x.TicketType.TicketTypeName.Contains(filters.TicketTypeName.ToLower()))
                && (filters.EmployeeFullName == null ||
                    x.Employee.FullName.Contains(filters.EmployeeFullName.ToLower()))
                && (filters.RenterId == null || x.Contract.RenterId == filters.RenterId)
                && (filters.RenterFullname == null ||
                    x.Contract.Renter.FullName.Contains(filters.RenterFullname.ToLower()))
                && (filters.RenterUsername == null || x.Contract.Renter.Username.Contains(filters.RenterUsername))
                && (filters.RenterEmail == null || x.Contract.Renter.Email.Contains(filters.RenterEmail)))
            .AsNoTracking();
    }

    public IQueryable<Ticket> GetTicketList(TicketFilter filters, int id, bool isManagement)
    {
        return isManagement switch
        {
            true => _context.Tickets
                .Include(x => x.Employee)
                .Include(x => x.Contract)
                .Include(x => x.TicketType)
                .Where(x => x.EmployeeId == id)
                // filter starts here
                .Where(x =>
                    (filters.Status == null || x.Status == filters.Status)
                    && (filters.TicketId == null || x.TicketId == filters.TicketId)
                    && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                    && (filters.CreateDate == null || x.CreateDate == filters.CreateDate)
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
                        x.Employee.FullName.Contains(filters.EmployeeFullName.ToLower())))
                .AsNoTracking(),

            false => _context.Tickets
                .Include(x => x.TicketType)
                .Include(x => x.Contract)
                .ThenInclude(x => x.Renter)
                .Where(x => x.Contract.RenterId == id)
                // filter starts here
                .Where(x =>
                    (filters.Status == null || x.Status == filters.Status)
                    && (filters.TicketId == null || x.TicketId == filters.TicketId)
                    && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                    && (filters.CreateDate == null || x.CreateDate == filters.CreateDate)
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
                        x.Employee.FullName.Contains(filters.EmployeeFullName.ToLower())))
                .AsNoTracking()
        };
    }

    public IQueryable<Ticket> GetTicketList(TicketFilter filters, int buildingId)
    {
        return _context.Tickets
            .Include(x => x.Employee)
            .Include(x => x.Contract)
            .Where(x => x.Contract.BuildingId == buildingId)
            .Include(x => x.TicketType)
            // filter starts here
            .Where(x =>
                (filters.Status == null || x.Status == filters.Status)
                && (filters.TicketId == null || x.TicketId == filters.TicketId)
                && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                && (filters.CreateDate == null || x.CreateDate == filters.CreateDate)
                && (filters.SolveDate == null || x.SolveDate == filters.SolveDate)
                && (filters.Amount == null || x.TotalAmount == filters.Amount)
                && (filters.TicketTypeId == null || x.TicketTypeId == filters.TicketTypeId)
                && (filters.ContractId == null || x.ContractId == filters.ContractId)
                && (filters.EmployeeId == null || x.EmployeeId == filters.EmployeeId)
                && (filters.Description == null || x.Description.Contains(filters.Description.ToLower()))
                && (filters.TicketTypeName == null ||
                    x.TicketType.TicketTypeName.Contains(filters.TicketTypeName.ToLower()))
                && (filters.ContractName == null || x.Contract.ContractName.Contains(filters.ContractName.ToLower()))
                && (filters.TicketTypeName == null ||
                    x.TicketType.TicketTypeName.Contains(filters.TicketTypeName.ToLower()))
                && (filters.EmployeeFullName == null ||
                    x.Employee.FullName.Contains(filters.EmployeeFullName.ToLower()))
                && (filters.RenterId == null || x.Contract.RenterId == filters.RenterId)
                && (filters.RenterFullname == null ||
                    x.Contract.Renter.FullName.Contains(filters.RenterFullname.ToLower()))
                && (filters.RenterUsername == null || x.Contract.Renter.Username.Contains(filters.RenterUsername))
                && (filters.RenterEmail == null || x.Contract.Renter.Email.Contains(filters.RenterEmail)))
            .AsNoTracking();
    }

    /// <summary>
    ///     Get ticket by id
    /// </summary>
    /// <param name="ticketId"></param>
    /// <returns></returns>
    public IQueryable<Ticket> GetTicketDetail(int? ticketId)
    {
        return _context.Tickets
            .Include(x => x.Employee)
            .Include(x => x.Contract)
            .ThenInclude(x => x.Renter)
            .Include(x => x.TicketType)
            .Where(x => x.TicketTypeId == x.TicketType.TicketTypeId)
            .Where(x => x.TicketId == ticketId);
    }


    public IQueryable<Ticket> GetTicketDetail(int? ticketId, int? renterId)
    {
        return _context.Tickets
            .Include(x => x.Employee)
            .Include(x => x.TicketType)
            .Include(x => x.Contract)
            .Where(x => x.TicketTypeId == x.TicketType.TicketTypeId)
            .Where(x => x.TicketId == ticketId && x.Contract.RenterId == renterId);
    }

    /// <summary>
    ///     AddFeedback new ticket to database
    /// </summary>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public async Task<Ticket> CreateTicket(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
        return ticket;
    }

    /// <summary>
    ///     UpdateFeedback ticket by id
    /// </summary>
    /// <param name="ticket"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> UpdateTicket(Ticket ticket)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticket.TicketId);
        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không có phiếu nào được tìm thấy"
            };

        ticketFound.TicketName = ticket.TicketName;
        ticketFound.Description = ticket.Description;
        ticketFound.SolveDate = ticket.SolveDate ?? ticketFound.SolveDate;
        ticketFound.TicketTypeId = ticket.TicketTypeId;

        _context.Attach(ticketFound).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Ticket updated successfully"
        };
    }

    public async Task<RepositoryResponse> UpdateTicketImage(Ticket ticket, int number)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticket!.TicketId);
        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không có phiếu nào được tìm thấy"
            };

        switch (number)
        {
            case 1:
                ticketFound.ImageUrl1 = ticket.ImageUrl1;
                break;
            case 2:
                ticketFound.ImageUrl2 = ticket.ImageUrl2;
                break;
            case 3:
                ticketFound.ImageUrl3 = ticket.ImageUrl3;
                break;
        }

        _context.Attach(ticketFound).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Ticket updated successfully"
        };
    }

    public async Task<RepositoryResponse> ApproveTicket(int id, CancellationToken token)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == id, token);

        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phiếu không tồn tại"
            };

        ticketFound.Status = "Solved";

        _context.Attach(ticketFound).State = EntityState.Modified;

        await _context.SaveChangesAsync(token);
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Đã xác nhận thành công"
        };
    }

    public async Task<RepositoryResponse> AcceptTicket(int ticketId, int userId, CancellationToken token)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticketId, token);

        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không có phiếu nào được tìm thấy"
            };

        ticketFound.EmployeeId = userId;
        ticketFound.Status = "Processing";

        await _context.SaveChangesAsync(token);

        _context.Attach(ticketFound).State = EntityState.Modified;

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Phiếu thu đã tiếp nhận"
        };
    }

    public async Task<RepositoryResponse> MoveTicketToCancelled(int ticketId, CancellationToken token)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticketId, token);

        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không có phiếu nào được tìm thấy"
            };

        ticketFound.CancelledReason = "Khách hàng huỷ phiếu";
        ticketFound.Status = "Processing";

        _context.Attach(ticketFound).State = EntityState.Modified;

        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Phiếu thu đã huỷ"
        };
    }

    public async Task<RepositoryResponse> SolveTicket(int ticketId, CancellationToken token)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticketId, token);

        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phiếu không tồn tại"
            };

        ticketFound.Status = "Confirming";

        _context.Attach(ticketFound).State = EntityState.Modified;

        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Đã xác nhận thành công"
        };
    }

    public async Task<RepositoryResponse> UpdateTicketStatus(Ticket updateTicket, CancellationToken token)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == updateTicket.TicketId, token);

        if (ticketFound == null)
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Phiếu không tồn tại"
            };

        ticketFound.Status = updateTicket.Status;

        _context.Attach(ticketFound).State = EntityState.Modified;

        await _context.SaveChangesAsync(token);

        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Đã xác nhận thành công"
        };
    }


    /// <summary>
    ///     DeleteFeedback ticket by id
    /// </summary>
    /// <param name="ticketId"></param>
    /// <returns></returns>
    public async Task<RepositoryResponse> DeleteTicket(int ticketId)
    {
        var ticketFound = await _context.Tickets
            .FirstOrDefaultAsync(x => x.TicketId == ticketId);

        if (ticketFound == null)

            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Không có phiếu nào được tìm thấy"
            };

        _context.Tickets.Remove(ticketFound);

        await _context.SaveChangesAsync();
        return new RepositoryResponse
        {
            IsSuccess = true,
            Message = "Phiếu thu đã xoá"
        };
    }
}