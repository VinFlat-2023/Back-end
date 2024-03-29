﻿using Application.IRepository;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationContext _context;
    private readonly ILoggerFactory _logger;

    public RepositoryWrapper(ApplicationContext context, IConfiguration configuration, ILoggerFactory logger)
    {
        _context = context;
        _configuration = configuration;
        _logger = logger;
    }

    public IInvoiceDetailRepository InvoiceDetails
    {
        get
        {
            if (_invoiceDetails == null) _invoiceDetails = new InvoiceDetailRepository(_context);
            return _invoiceDetails;
        }
    }

    public IAzureStorageRepository AzureStorage
    {
        get
        {
            if (_azureStorage == null) _azureStorage = new AzureStorageRepository(_configuration, _logger);
            return _azureStorage;
        }
    }

    public IEmployeeRepository Employees
    {
        get
        {
            if (_employees == null) _employees = new EmployeeRepository(_context);
            return _employees;
        }
    }

    public IAreaRepository Areas
    {
        get
        {
            if (_areas == null) _areas = new AreaRepository(_context);
            return _areas;
        }
    }

    public IBuildingRepository Buildings
    {
        get
        {
            if (_buildings == null) _buildings = new BuildingRepository(_context);
            return _buildings;
        }
    }

    public IContractRepository Contracts
    {
        get
        {
            if (_contracts == null) _contracts = new ContractRepository(_context);
            return _contracts;
        }
    }

    /*
    public IFeedbackRepository Feedbacks
    {
        get
        {
            if (_feedbacks == null) _feedbacks = new FeedbackRepository(_context);
            return _feedbacks;
        }
    }

    public IFeedbackTypeRepository FeedbackTypes
    {
        get
        {
            if (_feedbackTypes == null) _feedbackTypes = new FeedbackTypeRepository(_context);
            return _feedbackTypes;
        }
    }

    */
    public IFlatRepository Flats
    {
        get
        {
            if (_flats == null) _flats = new FlatRepository(_context);
            return _flats;
        }
    }

    public IFlatTypeRepository FlatTypes
    {
        get
        {
            if (_flatTypes == null) _flatTypes = new FlatTypeRepository(_context);
            return _flatTypes;
        }
    }

    public IInvoiceRepository Invoices
    {
        get
        {
            if (_invoices == null) _invoices = new InvoiceRepository(_context);
            return _invoices;
        }
    }

    public IRenterRepository Renters
    {
        get
        {
            if (_renters == null) _renters = new RenterRepository(_context);
            return _renters;
        }
    }

    public ITicketRepository Tickets
    {
        get
        {
            if (_tickets == null) _tickets = new TicketRepository(_context);
            return _tickets;
        }
    }

    public ITicketTypeRepository TicketTypes
    {
        get
        {
            if (_ticketTypes == null) _ticketTypes = new TicketTypeRepository(_context);
            return _ticketTypes;
        }
    }

    public IRoleRepository Roles
    {
        get
        {
            if (_roles == null) _roles = new RoleRepository(_context);
            return _roles;
        }
    }

    public IServiceEntityRepository ServiceEntities
    {
        get
        {
            if (_servicesEntity == null) _servicesEntity = new ServiceEntityRepository(_context);
            return _servicesEntity;
        }
    }

    public IServiceTypeRepository ServiceTypes
    {
        get
        {
            if (_serviceTypes == null) _serviceTypes = new ServiceTypeRepository(_context);
            return _serviceTypes;
        }
    }

    /*
    public IWalletRepository Wallets
    {
        get
        {
            if (_wallets == null) _wallets = new WalletRepository(_context);
            return _wallets;
        }
    }
    */

    /*
    public IDeviceRepository Devices
    {
        get
        {
            if (_devices == null) _devices = new DeviceRepository(_context);
            return _devices;
        }
    }
    */

    public IInvoiceTypeRepository InvoiceTypes
    {
        get
        {
            if (_invoiceTypes == null) _invoiceTypes = new InvoiceTypeRepository(_context);
            return _invoiceTypes;
        }
    }

    /*
    public INotificationRepository Notifications
    {
        get
        {
            if (_notification == null) _notification = new NotificationRepository(_context);
            return _notification;
        }
    }
    */
    public IRoomTypeRepository RoomsTypes
    {
        get
        {
            if (_roomType == null) _roomType = new RoomTypeRepository(_context);
            return _roomType;
        }
    }

    public IRoomRepository Rooms
    {
        get
        {
            if (_room == null) _room = new RoomRepository(_context);
            return _room;
        }
    }

    public IGetIdRepository GetId
    {
        get
        {
            if (_getId == null) _getId = new GetIdRepository(_context);
            return _getId;
        }
    }

    #region fields

    private IAzureStorageRepository _azureStorage;
    private IInvoiceTypeRepository _invoiceTypes;
    private IInvoiceDetailRepository _invoiceDetails;
    private IEmployeeRepository _employees;
    private IAreaRepository _areas;
    private IBuildingRepository _buildings;

    private IContractRepository _contracts;

    // private IFeedbackRepository _feedbacks;
    // private IFeedbackTypeRepository _feedbackTypes;
    private IFlatRepository _flats;
    private IFlatTypeRepository _flatTypes;
    private IInvoiceRepository _invoices;
    private IRenterRepository _renters;
    private ITicketRepository _tickets;
    private ITicketTypeRepository _ticketTypes;
    private IRoleRepository _roles;
    private IServiceEntityRepository _servicesEntity;

    private IServiceTypeRepository _serviceTypes;

    // private IWalletRepository _wallets;
    // private IDeviceRepository _devices;
    // private INotificationRepository _notification;
    private IRoomRepository _room;
    private IRoomTypeRepository _roomType;
    private IGetIdRepository _getId;

    #endregion
}