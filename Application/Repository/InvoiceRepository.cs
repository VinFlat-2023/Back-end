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


    public IQueryable<Invoice> GetInvoiceList(InvoiceFilter filter, int? buildingId, int? userId, bool isManagement)
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
                .Where(x => x.BuildingId == buildingId)
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
                .Where(x => x.RenterId == userId)
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
            .FirstOrDefaultAsync(x => x.RenterId == renterId && x.CreatedTime.Month == month, token);
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
    public async Task<List<Invoice>> GetUnpaidInvoice(int buildingId, CancellationToken token)
    {
        var test = await _context.Invoices
            .Include(x => x.Renter)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .Include(x => x.InvoiceDetails)
            .ThenInclude(x => x.PlaceholderForFee)
            .Include(x => x.InvoiceType)
            .Include(x => x.Contract)
            .ThenInclude(x => x.Flat)
            // false = unpaid invoice
            .OrderByDescending(x => x.CreatedTime)
            .Where(e => !e.Status && e.BuildingId == buildingId)
            .ToListAsync(token);

        return test;
    }

    public IEnumerable<Invoice> GetInvoiceListByMonth(int month)
    {
        return _context.Invoices
            .Where(x => x.CreatedTime.Month == month);
        //.Where(x.CreatedTime.Month == month);
    }

    public async Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId,
        IEnumerable<int> serviceIdList, CancellationToken token)
    {
        await using
            var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            foreach (var serviceId in serviceIdList)
            {
                var serviceCheckIfExistInDetail = await _context.InvoiceDetails
                    .Include(x => x.Service)
                    .FirstOrDefaultAsync(x
                        => x.ServiceId == serviceId && x.InvoiceId == invoiceId, token);
                
                if (serviceCheckIfExistInDetail != null && serviceCheckIfExistInDetail.Service != null)
                {
                    serviceCheckIfExistInDetail.Amount++;
                    serviceCheckIfExistInDetail.Price =
                        serviceCheckIfExistInDetail.Service.Price * serviceCheckIfExistInDetail.Amount;

                    _context.InvoiceDetails.Update(serviceCheckIfExistInDetail);
                }
                else
                {
                    var serviceCheck = await _context.Services
                        .FirstOrDefaultAsync(x => x.ServiceId == serviceId, token);

                    if (serviceCheck == null)
                    {
                        await transaction.RollbackAsync(token);
                        return new RepositoryResponse
                        {
                            IsSuccess = false,
                            Message = "Dịch vụ không tồn tại"
                        };
                    }

                    var serviceEntity = new InvoiceDetail
                    {
                        InvoiceId = invoiceId,
                        ServiceId = serviceId,
                        Name = serviceCheck.Name,
                        Price = serviceCheck.Price,
                        Amount = 1
                    };
                    await _context.InvoiceDetails.AddAsync(serviceEntity, token);
                }
            }

            await _context.SaveChangesAsync(token);

            await transaction.CommitAsync(token);

            return new RepositoryResponse
            {
                IsSuccess = true,
                Message = "Dịch vụ đã được thêm vào hóa đơn"
            };
        }
        catch
        {
            await transaction.RollbackAsync(token);
            return new RepositoryResponse
            {
                IsSuccess = false,
                Message = "Thêm dịch vụ vào hóa đơn thất bại"
            };
        }
    }

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoice(IEnumerable<int> invoices, int employeeId,
        CancellationToken token)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            foreach (var renterId in invoices)
            {
                var renterInvoiceCheck =
                    await GetAllUnpaidInvoicesByRenterInThisMonth(renterId, token);

                if (renterInvoiceCheck.Count != 0)
                    break;

                var renterContractCheck = await _context.Contracts
                    .FirstOrDefaultAsync(x
                        => x.RenterId == renterId &&
                           x.ContractStatus.ToLower() == "active", token);

                if (renterContractCheck == null)
                    break;

                var renter = await _context.Renters
                    .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

                if (renter == null)
                    break;

                var newInvoice = new Invoice
                {
                    RenterId = renterId,
                    ContractId = renterContractCheck.ContractId,
                    BuildingId = renterContractCheck.BuildingId,
                    InvoiceTypeId = 1,
                    Status = false,
                    IsLate = false,
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


    public async Task<RepositoryResponse> BatchInsertMonthlyInvoiceWithData(int buildingId, int employeeId,
        CancellationToken token)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            var renterList = await _context
                .Contracts
                .Where(x => x.ContractStatus.ToLower() == "active"
                            && x.BuildingId == buildingId)
                .Select(x => x.RenterId)
                .ToListAsync(token);

            foreach (var renterId in renterList)
            {
                var renterInvoiceCheck =
                    await GetAllUnpaidInvoicesByRenterInThisMonth(renterId, token);

                if (renterInvoiceCheck.Capacity != 0)
                    break;

                var renterContractCheck = await _context.Contracts
                    .FirstOrDefaultAsync(x
                        => x.RenterId == renterId &&
                           x.ContractStatus.ToLower() == "active", token);
                
                if (renterContractCheck == null)
                    break;

                var renter = await _context.Renters
                    .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

                if (renter == null)
                    break;

                var latestUnpaidInvoiceId = await GetLatestUnpaidInvoiceByRenter(renter.RenterId, token);

                var invoiceDetailList = await _context.InvoiceDetails
                    .Where(x => x.InvoiceId == latestUnpaidInvoiceId)
                    .ToListAsync(token);

                var flatData = await _context
                    .Flats.FirstOrDefaultAsync(x 
                        => x.FlatId == renterContractCheck.FlatId, token);

                if (flatData == null)
                    break;

                if (renterInvoiceCheck.Capacity == 1)
                {
                    var invoiceDetail = await GetInvoiceByRenterAndInvoiceId(renter.RenterId, latestUnpaidInvoiceId, token);

                    if (invoiceDetail == null)
                        break;

                    // updateInvoice 
                    invoiceDetail.DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                        DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).AddDays(10);

                    _context.Invoices.Attach(invoiceDetail);

                    await _context.SaveChangesAsync(token);
                }
                else
                {
                    var newInvoice = new Invoice
                    {
                        RenterId = renterId,
                        ContractId = renterContractCheck.ContractId,
                        BuildingId = renterContractCheck.BuildingId,
                        EmployeeId = employeeId,
                        InvoiceTypeId = 1,
                        Status = false,
                        IsLate = false,
                        CreatedTime = DateTime.Now,
                        DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                            DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).AddDays(10),
                        Name = "Hóa đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year + " của " +
                               renter.FullName,
                        Detail = "Hóa đơn tháng " + DateTime.Now.Month + " năm " + DateTime.Now.Year
                    };

                    await _context.Invoices.AddAsync(newInvoice, token);
                }

                foreach (var invoiceDetail in invoiceDetailList)
                {
                    if (invoiceDetail.Name != "Tiền thuê nhà")
                    {
                        var newInvoiceDetailForRent = new InvoiceDetail
                        {
                            Name = "Tiền thuê nhà",
                            Amount = 1,
                            Price = renterContractCheck.PriceForRent,
                            InvoiceId = latestUnpaidInvoiceId
                        };
                        await _context.InvoiceDetails.AddAsync(newInvoiceDetailForRent, token);
                    }

                    if (invoiceDetail.Name != "Tiền điện")
                    {
                        var electricityMetric = await _context
                            .Rooms
                            .Where(x => x.RoomId == renterContractCheck.RoomId)
                            .Select(x => x.ElectricityAttribute).FirstOrDefaultAsync(token);

                        var totalElectricityUsed = flatData.ElectricityMeterAfter - flatData.ElectricityMeterBefore;

                        if (totalElectricityUsed < 0)
                            break;

                        var totalPriceForElectricity =
                            renterContractCheck.PriceForElectricity * electricityMetric * totalElectricityUsed;

                        var newInvoiceDetailForRent = new InvoiceDetail
                        {
                            Name = "Tiền điện",
                            Amount = 1,
                            Price = totalPriceForElectricity,
                            InvoiceId = latestUnpaidInvoiceId
                        };
                        await _context.InvoiceDetails.AddAsync(newInvoiceDetailForRent, token);
                    }

                    if (invoiceDetail.Name != "Tiền nước")
                    {
                        var waterMetric = await _context
                            .Rooms
                            .Where(x => x.RoomId == renterContractCheck.RoomId)
                            .Select(x => x.ElectricityAttribute).FirstOrDefaultAsync(token);

                        var totalWaterUsed = flatData.WaterMeterAfter - flatData.WaterMeterBefore;

                        if (totalWaterUsed < 0)
                            break;

                        var totalPriceForWater =
                            renterContractCheck.PriceForWater * waterMetric * totalWaterUsed;

                        var newInvoiceDetailForRent = new InvoiceDetail
                        {
                            Name = "Tiền nước",
                            Amount = 1,
                            Price = totalPriceForWater,
                            InvoiceId = latestUnpaidInvoiceId
                        };
                        await _context.InvoiceDetails.AddAsync(newInvoiceDetailForRent, token);
                    }

                    if (invoiceDetail.Name != "Tiền dịch vụ")
                    {
                        var newInvoiceDetailForRent = new InvoiceDetail
                        {
                            Name = "Tiền dịch vụ",
                            Amount = 1,
                            Price = renterContractCheck.PriceForService,
                            InvoiceId = latestUnpaidInvoiceId
                        };
                        await _context.InvoiceDetails.AddAsync(newInvoiceDetailForRent, token);
                    }
                }

                var totalMoney = await _context.InvoiceDetails
                    .Where(x => x.InvoiceId == latestUnpaidInvoiceId)
                    .SumAsync(x => x.Price, cancellationToken: token);

                var invoice = await _context.Invoices
                    .FirstOrDefaultAsync(x => x.InvoiceId == latestUnpaidInvoiceId, cancellationToken: token);

                if (invoice == null)
                    break;
                
                invoice.TotalAmount = totalMoney;
                
                _context.Attach(invoice).State = EntityState.Modified;
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

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoice(int buildingId, int employeeId,
        CancellationToken token)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(token);
        try
        {
            var renterList = await _context
                .Contracts
                .Where(x => x.ContractStatus.ToLower() == "active"
                            && x.BuildingId == buildingId)
                .Select(x => x.RenterId)
                .ToListAsync(token);

            foreach (var renterId in renterList)
            {
                var renterInvoiceCheck =
                    await GetAllUnpaidInvoicesByRenterInThisMonth(renterId, token);

                if (renterInvoiceCheck.Capacity != 0)
                    break;

                var renterContractCheck = await _context.Contracts
                    .FirstOrDefaultAsync(x
                        => x.RenterId == renterId &&
                           x.ContractStatus.ToLower() == "active", token);

                if (renterContractCheck == null)
                    break;

                var renter = await _context.Renters
                    .FirstOrDefaultAsync(x => x.RenterId == renterId, token);

                if (renter == null)
                    break;

                var newInvoice = new Invoice
                {
                    RenterId = renterId,
                    ContractId = renterContractCheck.ContractId,
                    BuildingId = renterContractCheck.BuildingId,
                    EmployeeId = employeeId,
                    InvoiceTypeId = 1,
                    Status = false,
                    IsLate = false,
                    CreatedTime = DateTime.Now,
                    DueDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                        DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).AddDays(10),
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

    private async Task<List<Invoice>> GetAllUnpaidInvoicesByRenterInThisMonth(int renterId, CancellationToken token)
    {
        return await _context.Invoices
            .Where(x => x.RenterId == renterId
                        && x.Status == false && x.CreatedTime.Month == DateTime.Now.Month
                        && x.CreatedTime.Year == DateTime.Now.Year)
            .ToListAsync(token);
    }
}