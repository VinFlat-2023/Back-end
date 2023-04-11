using Application.IRepository;
using Domain.CustomEntities;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.Options;
using Domain.QueryFilter;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class InvoiceService : IInvoiceService
{
    private readonly PaginationOption _paginationOptions;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public InvoiceService(IRepositoryWrapper repositoryWrapper, IOptions<PaginationOption> paginationOptions)
    {
        _repositoryWrapper = repositoryWrapper;
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

    public async Task<Invoice?> GetInvoiceById(int? invoiceId)
    {
        return await _repositoryWrapper.Invoices.GetInvoiceDetail(invoiceId);
    }

    public async Task<Invoice?> AddInvoice(Invoice invoice)
    {
        return await _repositoryWrapper.Invoices.AddInvoice(invoice);
    }

    public async Task<Invoice?> UpdateInvoice(Invoice invoice)
    {
        return await _repositoryWrapper.Invoices.UpdateInvoice(invoice);
    }

    public async Task<bool> DeleteInvoice(int invoiceId)
    {
        return await _repositoryWrapper.Invoices.DeleteInvoice(invoiceId);
    }

    public async Task<Invoice?> GetInvoiceByRenterAndInvoiceId(int renterId, int invoiceId)
    {
        return await _repositoryWrapper.Invoices.GetInvoiceByRenterAndInvoiceId(renterId, invoiceId);
    }

    //Run on 1st day of months , generate this month empty invoice
    public async Task<bool> AutoGenerateEmptyInvoice()
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
                await _repositoryWrapper.Invoices.GetUnpaidInvoiceByRenterAndMonth(renter.RenterId, currentMonth - 1);
            var previous2MonthUnpaidInvoice =
                await _repositoryWrapper.Invoices.GetUnpaidInvoiceByRenterAndMonth(renter.RenterId, currentMonth - 2);
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
                    Amount = 0,
                    Status = false,
                    Detail = $"Hoá đơn tháng {currentMonth} cho {renter.Username}",
                    CreatedTime = DateTime.UtcNow, //Start of this month
                    DueDate = DateTime.UtcNow.AddMonths(1).AddDays(-1), //End of this month
                    RenterId = renter.RenterId,
                    InvoiceTypeId = 1
                };
                await _repositoryWrapper.Invoices.AddInvoice(createdInvoice);
            }
        }

        return true;
    }

    public async Task<int> GetLatestUnpaidInvoiceByRenter(int renterId)
    {
        return await _repositoryWrapper.Invoices.GetLatestUnpaidInvoiceByRenter(renterId);
    }

    public async Task<RepositoryResponse> AddServiceToLastInvoice(int invoiceId,
        IEnumerable<int> serviceId)
    {
        return await _repositoryWrapper.Invoices.AddServiceToLastInvoice(invoiceId, serviceId);
    }

    public async Task<RepositoryResponse> BatchInsertInvoice(IEnumerable<MassInvoiceCreateRequest> invoices)
    {
        return await _repositoryWrapper.Invoices.BatchInsertInvoice(invoices);
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
}