namespace Application.IRepository;

public interface IRepositoryWrapper
{
    public IAzureStorageRepository AzureStorage { get; }
    public IAccountRepository Accounts { get; }
    public IAreaRepository Areas { get; }
    public IBuildingRepository Buildings { get; }
    public IContractRepository Contracts { get; }
    public IFeedbackTypeRepository FeedbackTypes { get; }
    public IFeedbackRepository Feedbacks { get; }
    public IFlatRepository Flats { get; }
    public IFlatTypeRepository FlatTypes { get; }
    public IInvoiceRepository Invoices { get; }
    public IMajorRepository Majors { get; }
    public IRenterRepository Renters { get; }
    public ITicketRepository Tickets { get; }
    public ITicketTypeRepository TicketTypes { get; }
    public IRoleRepository Roles { get; }
    public IInvoiceTypeRepository InvoiceTypes { get; }
    public IInvoiceDetailRepository InvoiceDetails { get; }
    public IServiceEntityRepository ServiceEntities { get; }
    public IServiceTypeRepository ServiceTypes { get; }
    public IUniversityRepository Universities { get; }
    public IWalletRepository Wallets { get; }
    public IDeviceRepository Devices { get; }
    public INotificationRepository Notifications { get; }
    public IRoomRepository Rooms { get; }
    public IRoomTypeRepository RoomType { get; }
    public IGetIdRepository GetId { get; }
    public IAttributeRepository Attributes { get; }
}