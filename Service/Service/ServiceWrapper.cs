using Application.IRepository;
using Application.Repository;
using Domain.CustomEntities.Mail;
using Domain.Options;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.IHelper;
using Service.IService;

namespace Service.Service;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;
    private readonly IOptions<PaginationOption> _paginationOptions;
    private readonly IRepositoryWrapper _repositories;
    private readonly IRedisCacheHelper _redis;

    public ServiceWrapper(IRepositoryWrapper? repositories,
        ApplicationContext? context, IConfiguration configuration,
        IOptions<PaginationOption> paginationOptions, ILoggerFactory logger,
        IWebHostEnvironment env, IRedisCacheHelper redis)
    {
        _paginationOptions = paginationOptions;
        _configuration = configuration;
        _env = env;
        _redis = redis;
        if (repositories == null)
        {
            if (context == null)
                throw new ArgumentNullException(
                    $"Provide neither {nameof(repositories)} nor {nameof(context)}!\nCheck Dependency Injection");
            _ = new RepositoryWrapper(context, configuration, logger);
        }
        else
        {
            _repositories = repositories;
        }
    }

    public IAzureStorageService AzureStorage
    {
        get
        {
            if (_azureStorage == null) _azureStorage = new AzureStorageService(_repositories);
            return _azureStorage;
        }
    }

    public ITokenService Tokens
    {
        get
        {
            if (_tokens == null)
                _tokens = new TokenService(_configuration);
            return _tokens;
        }
    }


    public IEmployeeService Employees
    {
        get
        {
            if (_employee == null) _employee = new EmployeeService(_repositories, _paginationOptions);
            return _employee;
        }
    }

    public IAreaService Areas
    {
        get
        {
            if (_area == null) _area = new AreaService(_repositories, _paginationOptions, _redis);
            return _area;
        }
    }

    public IBuildingService Buildings
    {
        get
        {
            if (_building == null) _building = new BuildingService(_repositories, _paginationOptions);
            return _building;
        }
    }

    public IContractService Contracts
    {
        get
        {
            if (_contract == null) _contract = new ContractService(_repositories, _paginationOptions);
            return _contract;
        }
    }

    public IFeedbackService Feedbacks
    {
        get
        {
            if (_feedback == null) _feedback = new FeedbackService(_repositories, _paginationOptions);
            return _feedback;
        }
    }

    public IFeedbackTypeService FeedbackTypes
    {
        get
        {
            if (_feedbackType == null) _feedbackType = new FeedbackTypeService(_repositories, _paginationOptions);
            return _feedbackType;
        }
    }

    public IFlatService Flats
    {
        get
        {
            if (_flat == null) _flat = new FlatService(_repositories, _paginationOptions);
            return _flat;
        }
    }

    public IFlatTypeService FlatTypes
    {
        get
        {
            if (_flatType == null) _flatType = new FlatTypeService(_repositories, _paginationOptions);
            return _flatType;
        }
    }

    public IInvoiceService Invoices
    {
        get
        {
            if (_invoice == null) _invoice = new InvoiceService(_repositories, _paginationOptions);
            return _invoice;
        }
    }

    public IRenterService Renters
    {
        get
        {
            if (_renter == null) _renter = new RenterService(_repositories, _paginationOptions);
            return _renter;
        }
    }

    public IRoleService Roles
    {
        get
        {
            if (_roles == null) _roles = new RoleService(_repositories, _paginationOptions);
            return _roles;
        }
    }

    public ITicketService Tickets
    {
        get
        {
            if (_ticket == null) _ticket = new TicketService(_repositories, _paginationOptions);
            return _ticket;
        }
    }

    public ITicketTypeService TicketTypes
    {
        get
        {
            if (_ticketType == null) _ticketType = new TicketTypeService(_repositories, _paginationOptions);
            return _ticketType;
        }
    }

    public IServiceEntityService ServicesEntity
    {
        get
        {
            if (_serviceEntity == null) _serviceEntity = new ServiceEntityService(_repositories, _paginationOptions);
            return _serviceEntity;
        }
    }

    public IServiceTypeService ServiceTypes
    {
        get
        {
            if (_serviceType == null) _serviceType = new ServiceTypeService(_repositories, _paginationOptions);
            return _serviceType;
        }
    }

    public IWalletService Wallets
    {
        get
        {
            if (_wallet == null) _wallet = new WalletService(_repositories);
            return _wallet;
        }
    }

    public IDeviceService Devices
    {
        get
        {
            if (_device == null) _device = new DeviceService(_repositories);
            return _device;
        }
    }

    public IInvoiceTypeService InvoiceTypes
    {
        get
        {
            if (_invoiceType == null) _invoiceType = new InvoiceTypeService(_repositories, _paginationOptions);
            return _invoiceType;
        }
    }

    public IInvoiceDetailService InvoiceDetails
    {
        get
        {
            if (_invoiceDetail == null) _invoiceDetail = new InvoiceDetailService(_repositories, _paginationOptions);
            return _invoiceDetail;
        }
    }


    public IRoomTypeService RoomTypes
    {
        get
        {
            if (_roomType == null) _roomType = new RoomTypeService(_repositories, _paginationOptions);
            return _roomType;
        }
    }

    public IRoomService Rooms
    {
        get
        {
            if (_room == null) _room = new RoomService(_repositories, _paginationOptions);
            return _room;
        }
    }

    public IGetIdService GetId
    {
        get
        {
            if (_getId == null) _getId = new GetIdService(_repositories);
            return _getId;
        }
    }

    public INotificationService Notifications
    {
        get
        {
            if (_noti == null) _noti = new NotificationService(_repositories, _paginationOptions);
            return _noti;
        }
    }


    public ICustomeMailService Mails
    {
        get
        {
            if (_mail != null)
                return _mail;

            var emailConfig = _configuration
                .GetSection("EmailConfiguration")
                .Get<MailConfiguration>();

            _mail = new CustomeMailService(_env, emailConfig, _repositories);

            return _mail;
        }
    }

    #region fields

    private IAzureStorageService _azureStorage;
    private IEmployeeService _employee;
    private IAreaService _area;
    private IBuildingService _building;
    private IContractService _contract;
    private IFeedbackService _feedback;
    private IFeedbackTypeService _feedbackType;
    private IFlatService _flat;
    private IFlatTypeService _flatType;
    private IInvoiceService _invoice;
    private IInvoiceTypeService _invoiceType;
    private IInvoiceDetailService _invoiceDetail;
    private IRenterService _renter;
    private ITicketService _ticket;
    private ITicketTypeService _ticketType;
    private IRoleService _roles;
    private IServiceEntityService _serviceEntity;
    private IServiceTypeService _serviceType;
    private IWalletService _wallet;
    private ITokenService _tokens;
    private IDeviceService _device;
    private ICustomeMailService _mail;
    private INotificationService _noti;
    private IRoomTypeService _roomType;
    private IRoomService _room;
    private IGetIdService _getId;

    #endregion
}