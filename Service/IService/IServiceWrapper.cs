namespace Service.IService;

public interface IServiceWrapper
{
    public IAzureStorageService AzureStorage { get; }
    public IEmployeeService Employees { get; }
    public IAreaService Areas { get; }
    public IBuildingService Buildings { get; }
    public IContractService Contracts { get; }
    public IFeedbackService Feedbacks { get; }
    public IFeedbackTypeService FeedbackTypes { get; }
    public IFlatService Flats { get; }
    public IFlatTypeService FlatTypes { get; }
    public IInvoiceService Invoices { get; }
    public IInvoiceTypeService InvoiceTypes { get; }
    public IInvoiceDetailService InvoiceDetails { get; }
    public IRenterService Renters { get; }
    public ITicketService Tickets { get; }
    public ITicketTypeService TicketTypes { get; }
    public IRoleService Roles { get; }
    public ITokenService Tokens { get; }
    public IServiceEntityService ServicesEntity { get; }
    public IServiceTypeService ServiceTypes { get; }
    public IWalletService Wallets { get; }
    public IDeviceService Devices { get; }
    public ICustomeMailService Mails { get; }
    public INotificationService Notifications { get; }

    public IRoomService Rooms { get; }

    // public IRoomTypeService RoomType { get; }
    public IGetIdService GetId { get; }
}