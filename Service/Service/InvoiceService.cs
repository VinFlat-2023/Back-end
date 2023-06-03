using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class InvoiceService : IInvoiceService
{
    private readonly string _cacheKey = "invoice";
    private readonly string _cacheKeyBuilding = "invoice-building";
    private readonly string _cacheKeyPageNumber = "page-number-invoice";
    private readonly string _cacheKeyPageSize = "page-size-invoice";
    private readonly string _cacheUserId = "invoice-user-id";

    private readonly PaginationOption _paginationOptions;
    private readonly IRedisCacheHelper _redis;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions,
        IRedisCacheHelper redis)
    {
        _repositoryWrapper = repositoryWrapper;
        _redis = redis;
        _paginationOptions = paginationOptions.Value;
    }

    public async Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filters, CancellationToken token)
    {
        var queryable = _repositoryWrapper.Invoices.GetInvoiceList(filters);

        if (!queryable.Any())
            return null;

        var page = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var size = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var pagedList = await PagedList<Invoice>
            .Create(queryable, page, size, token);

        return pagedList;
    }

    public async Task<PagedList<Invoice>?> GetInvoiceList(InvoiceFilter filters, int? buildingId, int? userId,
        bool isManagement,
        CancellationToken token)
    {
        var pageNumber = filters.PageNumber ?? _paginationOptions.DefaultPageNumber;
        var pageSize = filters.PageSize ?? _paginationOptions.DefaultPageSize;

        var cacheDataList = await _redis.GetCachePagedDataAsync<PagedList<Invoice>>(_cacheKey);
        var cacheDataPageSize = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageSize);
        var cacheDataPageNumber = await _redis.GetCachePagedDataAsync<int>(_cacheKeyPageNumber);
        var cacheDataBuilding = await _redis.GetCachePagedDataAsync<int>(_cacheKeyBuilding);
        var cacheDataUserId = await _redis.GetCachePagedDataAsync<int>(_cacheUserId);

        var ifNullFilter = filters.GetType().GetProperties()
            .All(p => p.GetValue(filters) == null);

        if (cacheDataList != null)
        {
            if (ifNullFilter)
            {
                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
                await _redis.RemoveCacheDataAsync(_cacheUserId);
            }
            else
            {
                var matches =
                    cacheDataList.Where(x =>
                        (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                        && (filters.Status == null || x.Status == filters.Status)
                        && (filters.Amount == null || x.TotalAmount == filters.Amount)
                        && (filters.Detail == null || x.Detail == filters.Detail)
                        && (filters.RenterUsername == null ||
                            x.Renter.Username.ToLower().Contains(filters.RenterUsername.ToLower()))
                        && (filters.RenterFullname == null ||
                            x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower()))
                        && (filters.RenterPhoneNumber == null ||
                            x.Renter.PhoneNumber.ToLower().Contains(filters.RenterPhoneNumber.ToLower()))
                        && (filters.RenterEmail == null ||
                            x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                        && (filters.EmployeeName == null ||
                            x.Employee.FullName.ToLower().Contains(filters.EmployeeName.ToLower()))
                        && (filters.InvoiceTypeId == null || x.InvoiceTypeId == filters.InvoiceTypeId)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize
                        && cacheDataBuilding == buildingId);

                if (matches.Any())
                    return cacheDataList;

                var matches2 =
                    cacheDataList.Where(x =>
                        (filters.Name == null || x.Name.ToLower().Contains(filters.Name.ToLower()))
                        && (filters.Status == null || x.Status == filters.Status)
                        && (filters.Amount == null || x.TotalAmount == filters.Amount)
                        && (filters.Detail == null || x.Detail == filters.Detail)
                        && (filters.RenterUsername == null ||
                            x.Renter.Username.ToLower().Contains(filters.RenterUsername.ToLower()))
                        && (filters.RenterFullname == null ||
                            x.Renter.FullName.ToLower().Contains(filters.RenterFullname.ToLower()))
                        && (filters.RenterPhoneNumber == null ||
                            x.Renter.PhoneNumber.ToLower().Contains(filters.RenterPhoneNumber.ToLower()))
                        && (filters.RenterEmail == null ||
                            x.Renter.Email.ToLower().Contains(filters.RenterEmail.ToLower()))
                        && (filters.EmployeeName == null ||
                            x.Employee.FullName.ToLower().Contains(filters.EmployeeName.ToLower()))
                        && (filters.InvoiceTypeId == null || x.InvoiceTypeId == filters.InvoiceTypeId)
                        && cacheDataPageNumber == pageNumber && cacheDataPageSize == pageSize
                        && cacheDataUserId == userId);

                if (matches2.Any())
                    return cacheDataList;

                await _redis.RemoveCacheDataAsync(_cacheKey);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
                await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
                await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
                await _redis.RemoveCacheDataAsync(_cacheUserId);
            }
        }

        var queryable = _repositoryWrapper.Invoices.GetInvoiceList(filters, buildingId, userId, isManagement);

        if (!queryable.Any())
            return null;

        var pagedList = await PagedList<Invoice>
            .Create(queryable, pageNumber, pageSize, token);

        await _redis.SetCacheDataAsync(_cacheKey, pagedList, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageNumber, pageNumber, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyPageSize, pageSize, 10, 5);
        await _redis.SetCacheDataAsync(_cacheKeyBuilding, buildingId, 10, 5);
        await _redis.SetCacheDataAsync(_cacheUserId, userId, 10, 5);

        return pagedList;
    }

    public async Task<Invoice?> GetInvoiceById(int? invoiceId, CancellationToken token)
    {
        return await _repositoryWrapper.Invoices.GetInvoiceDetail(invoiceId, token);
    }

    public async Task<Invoice?> AddInvoice(Invoice invoice)
    {
        var response = await _repositoryWrapper.Invoices.AddInvoice(invoice);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
        await _redis.RemoveCacheDataAsync(_cacheUserId);
        return response;
    }

    public async Task<Invoice?> UpdateInvoice(Invoice invoice)
    {
        var response = await _repositoryWrapper.Invoices.UpdateInvoice(invoice);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
        await _redis.RemoveCacheDataAsync(_cacheUserId);
        return response;
    }

    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        return await _repositoryWrapper.Invoices.DeleteInvoice(invoiceId);
    }

    public async Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId, CancellationToken token)
    {
        return await _repositoryWrapper.Invoices.GetInvoiceByRenterAndInvoiceId(renterId, invoiceId, token);
    }

    //Run on 1st day of months , generate this month empty invoice
    public async Task<bool> AutoGenerateEmptyInvoice(CancellationToken token)
    {
        Console.WriteLine("\n\nAutoGenerateInvoice========================");
        //Get all user with active invoice
        var renters = _repositoryWrapper.Renters.GetRenterWithActiveContract();
        var currentMonth = DateTime.UtcNow.Month;
        foreach (var renter in renters)
        {
            Console.WriteLine($"User: {renter.Username}");
            //Check if user has paid last 2 months, true: gen new invoice, false: log, todo
            var previous1MonthUnpaidInvoice =
                await _repositoryWrapper.Invoices.GetUnpaidInvoiceByRenterAndMonth(renter.RenterId, currentMonth - 1,
                    token);
            var previous2MonthUnpaidInvoice =
                await _repositoryWrapper.Invoices.GetUnpaidInvoiceByRenterAndMonth(renter.RenterId, currentMonth - 2,
                    token);
            if (previous1MonthUnpaidInvoice != null && previous2MonthUnpaidInvoice != null)
            {
                Console.WriteLine($"Unpaid invoices of month {currentMonth - 1}: ");
                Console.WriteLine(
                    $"Username: {renter.Username}, Invoice name: {previous1MonthUnpaidInvoice.Name}, Created: {previous1MonthUnpaidInvoice.CreatedTime}, Status: {previous1MonthUnpaidInvoice.Status}");
                Console.WriteLine($"Unpaid invoices of month {currentMonth - 2}: ");
                Console.WriteLine(
                    $"Username: {renter.Username}, Invoice name: {previous2MonthUnpaidInvoice.Name}, Created: {previous1MonthUnpaidInvoice.CreatedTime}, Status: {previous2MonthUnpaidInvoice.Status}");
            }
            else
            {
                var createdInvoice = new Invoice
                {
                    Name = $"Hoá đơn tháng {currentMonth} cho {renter.Username}",
                    TotalAmount = 0,
                    Status = false,
                    Detail = $"Hoá đơn tháng {currentMonth} cho {renter.Username}",
                    CreatedTime = DateTime.UtcNow, //Start of this month
                    DueDate = DateTime.UtcNow.AddMonths(1).AddDays(-1),
                    RenterId = renter.RenterId,
                    InvoiceTypeId = 1
                };
                await _repositoryWrapper.Invoices.AddInvoice(createdInvoice);
            }
        }

        return true;
    }

    public async Task<int> GetLatestUnpaidInvoiceByRenter(int renterId, CancellationToken token)
    {
        return await _repositoryWrapper.Invoices.GetLatestUnpaidInvoiceByRenter(renterId, token);
    }

    public async Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId,
        IEnumerable<int> serviceId, CancellationToken token)
    {
        var response = await _repositoryWrapper.Invoices.AddServiceToLastInvoice(invoiceId, serviceId, token);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
        await _redis.RemoveCacheDataAsync(_cacheUserId);
        return response;
    }

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoice(int buildingForCurrentSupervisor, int employeeId,
        CancellationToken token)
    {
        var response = await _repositoryWrapper.Invoices.BatchInsertMonthlyInvoice(buildingForCurrentSupervisor,
            employeeId,
            token);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
        await _redis.RemoveCacheDataAsync(_cacheUserId);
        return response;
    }

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoiceWithData(int buildingForCurrentSupervisor,
        int employeeId, CancellationToken token)
    {
        var response = await _repositoryWrapper.Invoices.BatchInsertMonthlyInvoiceWithData(buildingForCurrentSupervisor,
            employeeId,
            token);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
        await _redis.RemoveCacheDataAsync(_cacheUserId);
        return response;
    }

    public async Task<bool> AutoFinishInvoice()
    {
        var thisMonthInvoices = _repositoryWrapper.Invoices.GetInvoiceListByMonth(DateTime.UtcNow.Month);
        foreach (var invoice in thisMonthInvoices)
        {
            Console.WriteLine(
                $"Invoice name: {invoice.Name}, Created: {invoice.CreatedTime}, Status: {invoice.Status}");
            //TODO: Finish invoice
            for (var i = 0; i <= 0; i++)
                Console.WriteLine("Anh Duc oi! finish dum em cai AutoFinishInvoice trong Invoice Service");
        }

        return true;
    }

    public async Task<RepositoryResponse> BatchInsertMonthlyInvoice(IEnumerable<int> invoices, int employeeId,
        CancellationToken token)
    {
        var response = await _repositoryWrapper.Invoices.BatchInsertMonthlyInvoice(invoices, employeeId, token);
        await _redis.RemoveCacheDataAsync(_cacheKey);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageSize);
        await _redis.RemoveCacheDataAsync(_cacheKeyPageNumber);
        await _redis.RemoveCacheDataAsync(_cacheKeyBuilding);
        await _redis.RemoveCacheDataAsync(_cacheUserId);
        return response;
    }
}