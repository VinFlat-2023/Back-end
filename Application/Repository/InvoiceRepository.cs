using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.QueryFilter;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationContext _context;

    public InvoiceRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all invoices
    /// </summary>
    /// <returns></returns>
    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter)
    {
        return _context.Invoices
            .Include(x => x.Employee)
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.PlaceholderForFee)
            .Include(x => x.InvoiceType)
            // filter starts here
            .Where(x =>
                (filter.Name == null || x.Name.ToLower().Contains(filter.Name.ToLower()))
                && (filter.Status == null || x.Status == filter.Status)
                && (filter.Amount == null || x.TotalAmount == filter.Amount)
                && (filter.Detail == null || x.Detail == filter.Detail)
                && (filter.RenterId == null || x.RenterId == filter.RenterId)
                && (filter.RenterUsername == null ||
                    x.Renter.Username.ToLower().Contains(filter.RenterUsername.ToLower()))
                && (filter.RenterFullname == null ||
                    x.Renter.FullName.ToLower().Contains(filter.RenterFullname.ToLower()))
                && (filter.RenterPhoneNumber == null ||
                    x.Renter.PhoneNumber.ToLower().Contains(filter.RenterPhoneNumber.ToLower()))
                && (filter.RenterEmail == null || x.Renter.Email.ToLower().Contains(filter.RenterEmail.ToLower()))
                && (filter.EmployeeId == null || x.EmployeeId == filter.EmployeeId)
                && (filter.EmployeeName == null ||
                    x.Employee.FullName.ToLower().Contains(filter.EmployeeName.ToLower()))
                && (filter.InvoiceTypeId == null || x.InvoiceTypeId == filter.InvoiceTypeId))
            .AsNoTracking();
    }


    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter, int id, bool isManagement)
    {
        return isManagement switch
        {
            true => _context.Invoices
                .Include(x => x.Employee)
                .Include(x => x.Renter)
                .Include(x => x.InvoiceDetails)
                .ThenInclude(x => x.Service)
                .ThenInclude(x => x.ServiceType)
                .Include(x => x.InvoiceDetails)
                .ThenInclude(x => x.PlaceholderForFee)
                .Include(x => x.InvoiceType)
                .Where(x => x.BuildingId == id)
                // filter starts here
                .Where(x =>
                    (filter.Name == null || x.Name.ToLower().Contains(filter.Name.ToLower()))
                    && (filter.Status == null || x.Status == filter.Status)
                    && (filter.Amount == null || x.TotalAmount == filter.Amount)
                    && (filter.Detail == null || x.Detail == filter.Detail)
                    && (filter.RenterUsername == null ||
                        x.Renter.Username.ToLower().Contains(filter.RenterUsername.ToLower()))
                    && (filter.RenterFullname == null ||
                        x.Renter.FullName.ToLower().Contains(filter.RenterFullname.ToLower()))
                    && (filter.RenterPhoneNumber == null ||
                        x.Renter.PhoneNumber.ToLower().Contains(filter.RenterPhoneNumber.ToLower()))
                    && (filter.RenterEmail == null || x.Renter.Email.ToLower().Contains(filter.RenterEmail.ToLower()))
                    && (filter.EmployeeName == null ||
                        x.Employee.FullName.ToLower().Contains(filter.EmployeeName.ToLower()))
                    && (filter.InvoiceTypeId == null || x.InvoiceTypeId == filter.InvoiceTypeId))
                .AsNoTracking(),

            false => _context.Invoices
                .Include(x => x.Employee)
                .Include(x => x.Renter)
                .Include(x => x.InvoiceDetails)
                .ThenInclude(x => x.Service)
                .ThenInclude(x => x.ServiceType)
                .Include(x => x.InvoiceDetails)
                .ThenInclude(x => x.PlaceholderForFee)
                .Include(x => x.InvoiceType)
                .Where(x => x.RenterId == id)
                // filter starts here
                .Where(x =>
                    (filter.Name == null || x.Name.ToLower().Contains(filter.Name.ToLower()))
                    && (filter.Status == null || x.Status == filter.Status)
                    && (filter.Amount == null || x.TotalAmount == filter.Amount)
                    && (filter.Detail == null || x.Detail == filter.Detail)
                    && (filter.RenterUsername == null ||
                        x.Renter.Username.ToLower().Contains(filter.RenterUsername.ToLower()))
                    && (filter.RenterFullname == null ||
                        x.Renter.FullName.ToLower().Contains(filter.RenterFullname.ToLower()))
                    && (filter.RenterPhoneNumber == null ||
                        x.Renter.PhoneNumber.ToLower().Contains(filter.RenterPhoneNumber.ToLower()))
                    && (filter.RenterEmail == null || x.Renter.Email.ToLower().Contains(filter.RenterEmail.ToLower()))
                    && (filter.EmployeeName == null ||
                        x.Employee.FullName.ToLower().Contains(filter.EmployeeName.ToLower()))
                    && (filter.InvoiceTypeId == null || x.InvoiceTypeId == filter.InvoiceTypeId))
                .AsNoTracking()
        };
    }

    /// <summary>
    ///     Get invoice by id
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<Invoice?> GetInvoiceDetail(int? invoiceId, CancellationToken token)
    {
        return await _context.Invoices
            .Include(x => x.Employee)
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.PlaceholderForFee)
            .Include(x => x.InvoiceType)
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId, token);
    }

    public async Task<int> GetLatestUnpaidInvoiceByRenter(int renterId, CancellationToken token)
    {
        return await _context.Invoices
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.PlaceholderForFee)
            .Include(x => x.InvoiceType)
            // false = unpaid invoice
            .Where(x => x.RenterId == renterId && x.Status == false)
            .OrderByDescending(x => x.CreatedTime)
            .Select(x => x.InvoiceId)
            .FirstOrDefaultAsync(token);
    }

    /// <summary>
    ///     Get invoice by id (Include renter id)
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<Invoice?> GetInvoiceIncludeRenter(int invoiceId, CancellationToken token)
    {
        return await _context.Invoices.Include(e => e.Renter)
            .FirstOrDefaultAsync(e => e.InvoiceId == invoiceId, token);
    }

    public async Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId,
        CancellationToken token)
    {
        return await _context.Invoices
            .Include(x => x.Employee)
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.PlaceholderForFee)
            .Include(x => x.InvoiceType)
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId && x.RenterId == renterId, token);
    }

    public async Task<Invoice?> GetUnpaidInvoiceByRenterAndMonth(int renterId, int month, CancellationToken token)
    {
        return await _context.Invoices
            .Where(x => x.Status == false)
            .FirstOrDefaultAsync(x => x.RenterId == renterId && x.CreatedTime.Value.Month == month, token);
    }

    /// <summary>
    ///     Add new invoice
    /// </summary>
    /// <param name="invoice"></param>
    /// <returns></returns>
    public async Task<Invoice> AddInvoice(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
        return invoice;
    }

    /// <summary>
    ///     Update invoice
    /// </summary>
    /// <param name="invoice"></param>
    /// <returns></returns>
    public async Task<Invoice?> UpdateInvoice(Invoice invoice)
    {
        var invoiceData = await _context.Invoices
            .FirstOrDefaultAsync(x => x.InvoiceId == invoice.InvoiceId);

        if (invoiceData == null)
            return null;

        invoiceData.Name = invoice.Name;
        invoiceData.Status = invoice.Status;
        invoiceData.Detail = invoice.Detail;
        invoiceData.DueDate = invoice.DueDate;
        invoiceData.PaymentTime = invoice.PaymentTime;

        _context.Attach(invoiceData).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return invoiceData;
    }

    /// <summary>
    ///     Delete invoice
    /// </summary>
    /// <param name="invoiceId"></param>
    /// <returns></returns>
    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        var invoiceFound = await _context.Invoices
            .FirstOrDefaultAsync(x => x.InvoiceId == invoiceId);
        if (invoiceFound == null)
            return false;

        _context.Invoices.Remove(invoiceFound);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///     Get unpaid invoices
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<List<Invoice>> GetUnpaidInvoice(CancellationToken token)
    {
        return await _context.Invoices
            .Include(e => e.Renter)
            .Include(e => e.InvoiceDetails)
            .ThenInclude(e => e.Service)
            .Where(e => !e.Status).ToListAsync(token);
    }

    public IEnumerable<Invoice> GetInvoiceListByMonth(int month)
    {
        return _context.Invoices
            .Where(x => x.Status == false && x.CreatedTime.Value.Month == month);
        //.Where(x.CreatedTime.Month == month);
    }

    public async Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId,
        IEnumerable<int> serviceId)
    {
        await using
            var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            foreach (var service in serviceId)
            {
                var serviceEntity = new InvoiceDetail
                {
                    InvoiceId = invoiceId,
                    ServiceId = service
                };

                _context.InvoiceDetails.Add(serviceEntity);
            }

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Dịch vụ đã được thêm vào hóa đơn"
            };
        }
        catch
        {
            await transaction.RollbackAsync();
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Thêm dịch vụ vào hóa đơn thất bại"
            };
        }
    }

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoice(IEnumerable<int> invoices, CancellationToken token)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            var listOfUnpaidInvoice = new List<int>();

            var listOfRenterNoLongerActive = new List<int>();

            var listOfRenterNotExist = new List<int>();

            foreach (var renterId in invoices)
            {
                var renterInvoiceCheck =
                    await GetLatestUnpaidInvoiceByRenter(renterId, token);

                if (renterInvoiceCheck != 0)
                {
                    listOfUnpaidInvoice.Add(renterId);
                    break;
                }

                var renterContractCheck = await _context.Contracts
                    .FirstOrDefaultAsync(x
                        => x.RenterId == renterId &&
                           x.ContractStatus.ToLower() == "active", token);

                if (renterContractCheck == null)
                {
                    listOfRenterNoLongerActive.Add(renterId);
                    break;
                }

                var renter = await _context.Renters
                    .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

                if (renter == null)
                {
                    listOfRenterNotExist.Add(renterId);
                    break;
                }

                var newInvoice = new Invoice
                {
                    RenterId = renterId,
                    ContractId = renterContractCheck.ContractId,
                    BuildingId = renterContractCheck.BuildingId,
                    InvoiceTypeId = 1,
                    Status = false,
                    CreatedTime = DateTime.Now,
                    DueDate = DateTime.Now.AddMonths(1).AddDays(9),
                    Name = "Hóa đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " của " +
                           renter.FullName,
                    Detail = "Hóa đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year
                };

                await _context.Invoices.AddAsync(newInvoice, token);
            }

            await _context.SaveChangesAsync(token);

            await transaction.CommitAsync(token);

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Hóa đơn đã được tạo thành công"
            };
        }
        catch
        {
            await transaction.RollbackAsync(token);
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo hóa đơn thất bại"
            };
        }
    }

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoice(int buildingId, CancellationToken token)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            var listOfUnpaidInvoice = new List<int>();

            var listOfRenterNoLongerActive = new List<int>();

            var listOfRenterNotExist = new List<int>();

            var renterList = await _context
                .Contracts
                .Where(x => x.ContractStatus.ToLower() == "active"
                            && x.BuildingId == buildingId)
                .DistinctBy(x => x.RenterId)
                .Select(x => x.RenterId)
                .ToListAsync(token);

            var listCount = renterList;

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = renterList.Count.ToString()
            };

            foreach (var renterId in renterList)
            {
                var renterInvoiceCheck =
                    await GetLatestUnpaidInvoiceByRenter(renterId, token);

                if (renterInvoiceCheck != 0)
                {
                    listOfUnpaidInvoice.Add(renterId);
                    break;
                }

                var renterContractCheck = await _context.Contracts
                    .FirstOrDefaultAsync(x
                        => x.RenterId == renterId &&
                           x.ContractStatus.ToLower() == "active", token);

                if (renterContractCheck == null)
                {
                    listOfRenterNoLongerActive.Add(renterId);
                    break;
                }

                var renter = await _context.Renters
                    .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

                if (renter == null)
                {
                    listOfRenterNotExist.Add(renterId);
                    break;
                }

                var newInvoice = new Invoice
                {
                    RenterId = renterId,
                    ContractId = renterContractCheck.ContractId,
                    BuildingId = renterContractCheck.BuildingId,
                    InvoiceTypeId = 1,
                    Status = false,
                    CreatedTime = DateTime.Now,
                    DueDate = DateTime.Now.AddMonths(1).AddDays(9),
                    Name = "Hóa đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " của " +
                           renter.FullName,
                    Detail = "Hóa đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year
                };

                await _context.Invoices.AddAsync(newInvoice, token);
            }

            await _context.SaveChangesAsync(token);

            await transaction.CommitAsync(token);

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Hóa đơn đã được tạo thành công"
            };
        }
        catch
        {
            await transaction.RollbackAsync(token);
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Tạo hóa đơn thất bại"
            };
        }
    }
}