namespace Service.IService;

public interface IServiceWrapper
{
    public IAzureStorageService AzureStorage { get; }
    public IAccountService Accounts { get; }
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
    public IMajorService Majors { get; }
    public IRenterService Renters { get; }
    public ITicketService Tickets { get; }
    public ITicketTypeService TicketTypes { get; }
    public IRoleService Roles { get; }
    public ITokenService Tokens { get; }
    public IServiceEntityService ServicesEntity { get; }
    public IServiceTypeService ServiceTypes { get; }
    public IUniversityService Universities { get; }
    public IWalletService Wallets { get; }
    public IDeviceService Devices { get; }
    public ICustomeMailService Mails { get; }
    public INotificationService Notifications { get; }
    public IRoomService Rooms { get; }
    public IGetIdService GetId { get; }
    public IAttributeForNumericService Attributes { get; }
}