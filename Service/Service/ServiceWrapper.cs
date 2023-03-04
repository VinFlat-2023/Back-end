using Application.IRepository;
using Application.Repository;
using Domain.CustomEntities.Mail;
using Domain.Options;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service.IService;

namespace Service.Service;

public class ServiceWrapper : IServiceWrapper
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;
    private readonly IOptions<PaginationOption> _paginationOptions;
    private readonly IRepositoryWrapper _repositories;

    public ServiceWrapper(IRepositoryWrapper? repositories,
        ApplicationContext? context, IConfiguration configuration,
        IOptions<PaginationOption> paginationOptions, ILoggerFactory logger,
        IWebHostEnvironment env)
    {
        _paginationOptions = paginationOptions;
        _configuration = configuration;
        _env = env;
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


    public IAccountService Accounts
    {
        get
        {
            if (_account == null) _account = new AccountService(_repositories, _paginationOptions);
            return _account;
        }
    }

    public IAreaService Areas
    {
        get
        {
            if (_area == null) _area = new AreaService(_repositories, _paginationOptions);
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
            if (_contracts == null) _contracts = new ContractService(_repositories, _paginationOptions);
            return _contracts;
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

    public IMajorService Majors
    {
        get
        {
            if (_major == null) _major = new MajorService(_repositories, _paginationOptions);
            return _major;
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

    public IUniversityService Universities
    {
        get
        {
            if (_universities == null) _universities = new UniversityService(_repositories, _paginationOptions);
            return _universities;
        }
    }

    public IWalletService Wallets
    {
        get
        {
            if (_wallets == null) _wallets = new WalletService(_repositories);
            return _wallets;
        }
    }

    public IDeviceService Devices
    {
        get
        {
            if (_devices == null) _devices = new DeviceService(_repositories);
            return _devices;
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


    public IRoomService Rooms
    {
        get
        {
            if (_room == null) _room = new RoomService(_repositories);
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
            if (_mails != null)
                return _mails;

            var emailConfig = _configuration
                .GetSection("EmailConfiguration")
                .Get<MailConfiguration>();

            _mails = new CustomeMailService(_env, emailConfig, _repositories);

            return _mails;
        }
    }

    #region fields

    private IAzureStorageService _azureStorage;
    private IAccountService _account;
    private IAreaService _area;
    private IBuildingService _building;
    private IContractService _contracts;
    private IFeedbackService _feedback;
    private IFeedbackTypeService _feedbackType;
    private IFlatService _flat;
    private IFlatTypeService _flatType;
    private IInvoiceService _invoice;
    private IInvoiceTypeService _invoiceType;
    private IInvoiceDetailService _invoiceDetail;
    private IMajorService _major;
    private IRenterService _renter;
    private ITicketService _ticket;
    private ITicketTypeService _ticketType;
    private IRoleService _roles;
    private IServiceEntityService _serviceEntity;
    private IServiceTypeService _serviceType;
    private IUniversityService _universities;
    private IWalletService _wallets;
    private ITokenService _tokens;
    private IDeviceService _devices;
    private ICustomeMailService _mails;
    private INotificationService _noti;
    private IRoomService _room;
    private IGetIdService _getId;

    #endregion
}