namespace Application.IRepository;

public interface IRepositoryWrapper
{
    public IAzureStorageRepository AzureStorage { get; }
    public IEmployeeRepository Employees { get; }
    public IAreaRepository Areas { get; }
    public IBuildingRepository Buildings { get; }

    public IContractRepository Contracts { get; }

    // public IFeedbackTypeRepository FeedbackTypes { get; }
    // public IFeedbackRepository Feedbacks { get; }
    public IFlatRepository Flats { get; }
    public IFlatTypeRepository FlatTypes { get; }
    public IInvoiceRepository Invoices { get; }
    public IRenterRepository Renters { get; }
    public ITicketRepository Tickets { get; }
    public ITicketTypeRepository TicketTypes { get; }
    public IRoleRepository Roles { get; }
    public IInvoiceTypeRepository InvoiceTypes { get; }
    public IInvoiceDetailRepository InvoiceDetails { get; }
    public IServiceEntityRepository ServiceEntities { get; }

    public IServiceTypeRepository ServiceTypes { get; }

    // public IWalletRepository Wallets { get; }
    // public IDeviceRepository Devices { get; }
    // public INotificationRepository Notifications { get; }
    public IRoomTypeRepository RoomsTypes { get; }
    public IRoomRepository Rooms { get; }
    public IGetIdRepository GetId { get; }
}