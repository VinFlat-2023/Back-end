using AutoMapper;
using Domain.CustomEntities.Mail;
using Domain.CustomEntities.MomoEntities;
using Domain.EntitiesDTO.MailMessageDTO;
using Domain.EntitiesDTO.NotificationDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Area;
using Domain.EntityRequest.Building;
using Domain.EntityRequest.Contract;
using Domain.EntityRequest.Employee;
using Domain.EntityRequest.FeedBack;
using Domain.EntityRequest.FeedbackType;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceDetail;
using Domain.EntityRequest.InvoiceType;
using Domain.EntityRequest.Renter;
using Domain.EntityRequest.Role;
using Domain.EntityRequest.Service;
using Domain.EntityRequest.ServiceType;
using Domain.EntityRequest.Ticket;
using Domain.EntityRequest.TicketType;
using Domain.EntityRequest.Wallet;
using Domain.EnumEntities;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Responses;
using Domain.Utils;
using Domain.ViewModel.AreaEntity;
using Domain.ViewModel.BuildingEntity;
using Domain.ViewModel.ContractEntity;
using Domain.ViewModel.EmployeeEntity;
using Domain.ViewModel.FeedbackEntity;
using Domain.ViewModel.FeedbackTypeDetail;
using Domain.ViewModel.FlatEntity;
using Domain.ViewModel.FlatTypeEntity;
using Domain.ViewModel.InvoiceEntity;
using Domain.ViewModel.InvoiceTypeEntity;
using Domain.ViewModel.PlaceholderForFeeEntity;
using Domain.ViewModel.RenterEntity;
using Domain.ViewModel.RoleEntity;
using Domain.ViewModel.RoomEntity;
using Domain.ViewModel.RoomTypeEntity;
using Domain.ViewModel.ServiceEntity;
using Domain.ViewModel.ServiceTypeEntity;
using Domain.ViewModel.TicketEntity;
using Domain.ViewModel.TicketTypeEntity;
using Domain.ViewModel.UtilitiesFlatEntity;
using Domain.ViewModel.UtilityEntity;
using MimeKit;

namespace API.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // Basic DTOs
        MapEmployee();
        MapArea();
        MapBuilding();
        MapContract();
        MapContractHistory();
        MapFeedback();
        MapFeedbackType();
        MapFlat();
        MapFlatType();
        MapInvoice();
        MapInvoiceDetail();
        MapInvoiceType();
        MapRenter();
        MapTicket();
        MapRequestType();
        MapRole();
        MapService();
        MapServiceType();
        MapWalletAndWalletType();
        MapMail();
        MapNotiAndNotiType();
        MapPlaceholder();
        MapUtilitiesFlat();
        MapUtility();
        MapRoomType();
        MapRoom();
    }

    /*
    private void MapRoomType()
    {
        CreateMap<RoomTypeFilterRequest, RoomTypeFilter>()
            .ReverseMap();

        CreateMap<RoomType, RoomType>()
            .ReverseMap();

        CreateMap<RoomType, RoomTypeDetailEntity>()
            .ReverseMap();

        CreateMap<RoomTypeDetailEntity, RoomType>()
            .ReverseMap();
    }
    */

    private void MapRoomType()
    {
        CreateMap<RoomType, RoomTypeBasicDetailEntity>()
            .ReverseMap();

        CreateMap<RoomTypeBasicDetailEntity, RoomType>()
            .ReverseMap();

        CreateMap<RoomType, RoomTypeDetailEntity>()
            .ReverseMap();

        CreateMap<RoomTypeDetailEntity, RoomType>()
            .ReverseMap();

        CreateMap<RoomTypeFilterRequest, RoomTypeFilter>()
            .ReverseMap();
    }

    private void MapRoom()
    {
        CreateMap<Room, RoomFilterRequest>()
            .ReverseMap();

        CreateMap<RoomFilterRequest, RoomFilter>()
            .ReverseMap();

        CreateMap<MetricRoomFilterRequest, MetricRoomFilter>()
            .ReverseMap();

        CreateMap<Room, RoomDetailEntity>()
            .ReverseMap();

        CreateMap<RoomDetailEntity, Room>()
            .ReverseMap();

        CreateMap<Room, RoomBasicDetailEntity>()
            .ReverseMap();

        CreateMap<RoomBasicDetailEntity, Room>()
            .ReverseMap();
    }


    private void MapInvoiceType()
    {
        CreateMap<InvoiceTypeCreateRequest, InvoiceType>()
            .ReverseMap();

        CreateMap<InvoiceTypeUpdateRequest, InvoiceType>()
            .ReverseMap();

        CreateMap<InvoiceTypeFilterRequest, InvoiceTypeFilter>()
            .ReverseMap();

        CreateMap<InvoiceTypeDetailEntity, InvoiceType>()
            .ForAllMembers(o => o.ExplicitExpansion());

        CreateMap<InvoiceType, InvoiceTypeDetailEntity>()
            .ReverseMap();
    }

    private void MapUtility()
    {
        CreateMap<Utility, UtilityDetailEntity>()
            .ReverseMap();

        CreateMap<UtilityDetailEntity, Utility>()
            .ReverseMap();

        CreateMap<Utility, UtilitiesFlatDetailEntity>()
            .ReverseMap();

        CreateMap<UtilitiesFlatDetailEntity, Utility>()
            .ReverseMap();
    }

    private void MapUtilitiesFlat()
    {
        CreateMap<UtilitiesRoom, UtilitiesFlatDetailEntity>()
            .ReverseMap();

        CreateMap<UtilitiesFlatDetailEntity, UtilitiesRoom>()
            .ReverseMap();
    }

    private void MapInvoiceDetail()
    {
        CreateMap<InvoiceDetailCreateRequest, InvoiceDetail>()
            .ReverseMap();
        CreateMap<InvoiceDetailUpdateRequest, InvoiceDetail>()
            .ReverseMap();
        CreateMap<InvoiceDetailFilterRequest, InvoiceDetailFilter>()
            .ReverseMap();
        CreateMap<InvoiceDataDetailEntity, InvoiceDetail>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<InvoiceDetail, InvoiceDataDetailEntity>()
            .ReverseMap();
    }

    private void MapMail()
    {
        //CreateMap<MailMessageEntity, MailMessageDto>();
        CreateMap<MailMessageDto, MailMessageEntity>()
            .ForMember(
                e => e.Receivers,
                opt => opt.MapFrom(dto => dto.Receivers.Select(receiver => new MailboxAddress(receiver)))
            )
            .ForMember( //Do not touch. This fixes error
                e => e.Attachments,
                opt => opt.MapFrom(dto => new List<IFormFile>(dto.Attachments))
            );
    }

    private void MapServiceType()
    {
        CreateMap<ServiceTypeCreateRequest, ServiceType>()
            .ReverseMap();
        CreateMap<ServiceTypeUpdateRequest, ServiceType>()
            .ReverseMap();
        CreateMap<ServiceTypeFilterRequest, ServiceTypeFilter>()
            .ReverseMap();
        CreateMap<ServiceTypeDetailEntity, ServiceType>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ServiceType, ServiceTypeDetailEntity>()
            .ReverseMap();
    }

    private void MapPlaceholder()
    {
        CreateMap<PlaceholderForFeeDetailEntity, PlaceholderForFee>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<PlaceholderForFee, PlaceholderForFeeDetailEntity>()
            .ReverseMap();

        CreateMap<PlaceholderForFeeDetailEmailEntity, PlaceholderForFee>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<PlaceholderForFee, PlaceholderForFeeDetailEmailEntity>()
            .ReverseMap();
    }

    private void MapService()
    {
        CreateMap<ServiceCreateRequest, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceUpdateRequest, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceFilterRequest, ServiceEntityFilter>()
            .ReverseMap();

        CreateMap<ServiceEntity, ServiceDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ServiceDetailEntity, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceEntity, ServiceDetailEntity>()
            .ReverseMap();

        CreateMap<ServiceDetailEntitySupervisor, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceEntity, ServiceDetailEntitySupervisor>()
            .ReverseMap();

        CreateMap<ServiceBasicDetailEntity, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceEntity, ServiceBasicDetailEntity>()
            .ReverseMap();

        CreateMap<ServiceEntity, ServiceDetailEmailEntity>()
            .ReverseMap();

        CreateMap<ServiceDetailEmailEntity, ServiceEntity>()
            .ReverseMap();
    }

    private void MapRole()
    {
        CreateMap<RoleCreateRequest, Role>()
            .ReverseMap();
        CreateMap<RoleUpdateRequest, Role>()
            .ReverseMap();
        CreateMap<RoleFilterRequest, RoleFilter>()
            .ReverseMap();
        CreateMap<RoleDetailEntity, Role>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Role, RoleDetailEntity>()
            .ReverseMap();
    }

    private void MapRequestType()
    {
        CreateMap<TicketTypeCreateRequest, TicketType>()
            .ReverseMap();
        CreateMap<TicketTypeUpdateRequest, TicketType>()
            .ReverseMap();
        CreateMap<TicketTypeFilterRequest, TicketTypeFilter>()
            .ReverseMap();
        CreateMap<TicketTypeDetailEntity, TicketType>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<TicketType, TicketTypeDetailEntity>()
            .ReverseMap();
    }

    private void MapTicket()
    {
        CreateMap<Ticket, TicketCreateRequest>()
            .ReverseMap();
        CreateMap<TicketUpdateRequest, Ticket>()
            .ReverseMap();
        CreateMap<Ticket, TicketUpdateRequest>()
            .ReverseMap();
        CreateMap<TicketFilterRequest, TicketFilter>()
            .ReverseMap();
        CreateMap<Ticket, TicketDetailEntity>()
            .ReverseMap();
        CreateMap<TicketDetailEntity, TicketFilter>()
            .ReverseMap();
    }

    private void MapInvoice()
    {
        CreateMap<InvoiceCreateRequest, Invoice>()
            .ForMember(e => e.DueDate,
                option => option.MapFrom(r => r.DueDate));
        CreateMap<Invoice, InvoiceCreateRequest>()
            .ReverseMap();
        CreateMap<InvoiceUpdateRequest, Invoice>()
            .ForMember(e => e.DueDate,
                option => option.MapFrom(r => r.DueDate))
            .ForMember(e => e.PaymentTime,
                option => option.MapFrom(r => r.PaymentTime));
        CreateMap<Invoice, InvoiceUpdateRequest>()
            .ReverseMap();
        CreateMap<InvoiceFilterRequest, InvoiceFilter>()
            .ReverseMap();

        CreateMap<InvoiceRenterDetailEntity, Invoice>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Invoice, InvoiceRenterDetailEntity>()
            .ReverseMap();

        CreateMap<Invoice, InvoiceEmailDetailEntity>()
            .ReverseMap();

        CreateMap<InvoiceEmailDetailEntity, Invoice>()
            .ReverseMap();
    }

    private void MapFlatType()
    {
        CreateMap<FlatTypeCreateRequest, FlatType>()
            .ReverseMap();
        CreateMap<FlatTypeUpdateRequest, FlatType>()
            .ReverseMap();

        CreateMap<FlatTypeFilterRequest, FlatTypeFilter>();

        CreateMap<FlatType, FlatTypeDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FlatTypeDetailEntity, FlatType>()
            .ReverseMap();
    }

    private void MapFlat()
    {
        CreateMap<FlatCreateRequest, Flat>()
            .ReverseMap();
        CreateMap<FlatUpdateRequest, Flat>()
            .ReverseMap();

        CreateMap<FlatFilterRequest, FlatFilter>()
            .ReverseMap();

        CreateMap<MetricFlatFilterRequest, MetricFlatFilter>()
            .ReverseMap();

        CreateMap<Flat, FlatDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FlatDetailEntity, Flat>()
            .ReverseMap();

        CreateMap<FlatBasicDetailEntity, Flat>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Flat, FlatBasicDetailEntity>()
            .ReverseMap();

        CreateMap<FlatBasicDetailEntity, Flat>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Flat, FlatBasicDetailEntity>()
            .ReverseMap();
    }

    private void MapFeedbackType()
    {
        CreateMap<FeedbackTypeCreateRequest, FeedbackType>()
            .ReverseMap();
        CreateMap<FeedbackTypeUpdateRequest, FeedbackType>()
            .ReverseMap();
        CreateMap<FeedbackTypeFilterRequest, FeedbackTypeFilter>()
            .ReverseMap();

        CreateMap<FeedbackTypeDetailEntity, FeedbackType>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FeedbackType, FeedbackTypeDetailEntity>()
            .ReverseMap();
    }

    private void MapFeedback()
    {
        CreateMap<FeedbackCreateRequest, Feedback>()
            .ReverseMap();
        CreateMap<FeedbackUpdateRequest, Feedback>()
            .ReverseMap();
        CreateMap<FeedbackFilterRequest, FeedbackFilter>()
            .ReverseMap();

        CreateMap<FeedbackDetailEntity, Feedback>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Feedback, FeedbackDetailEntity>()
            .ReverseMap();
    }

    private void MapContractHistory()
    {
        /*
        CreateMap<ContractHistory, ContractHistoryDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContractHistoryDto, ContractHistory>()
            .ReverseMap();
        CreateMap<ContractHistoryCreateRequest, ContractHistory>()
            .ForMember(c => c.ContractExpiredDate,
                option => option.MapFrom(w => w.ContractExpiredDate.ConvertToDateTime()));
        CreateMap<ContractHistory, ContractHistoryCreateRequest>();
        CreateMap<ContractHistoryUpdateRequest, ContractHistory>()
            .ForMember(c => c.ContractExpiredDate,
                option => option.MapFrom(w => w.ContractExpiredDate.ConvertToDateTime()));
        CreateMap<ContractHistory, ContractHistoryUpdateRequest>();
        CreateMap<ContractHistoryFilterRequest, ContractHistoryFilter>()
            .ReverseMap();

            CreateMap<ContractHistory, ContractHistoryDto>()
                .ForAllMembers(o => o.ExplicitExpansion());
            CreateMap<ContractHistoryDto, ContractHistory>()
                .ReverseMap();
            CreateMap<ContractHistoryCreateRequest, ContractHistory>()
                .ReverseMap();
            CreateMap<ContractHistoryUpdateRequest, ContractHistory>()
                .ReverseMap();
            CreateMap<ContractHistoryFilterRequest, ContractHistoryFilter>()
                .ReverseMap();
                */
    }

    private void MapContract()
    {
        CreateMap<ContractCreateRequest, Contract>()
            .ForMember(c => c.DateSigned,
                option => option.MapFrom(w => w.DateSigned))
            .ForMember(c => c.CreatedDate,
                option => option.MapFrom(w => w.StartDate))
            .ForMember(c => c.EndDate,
                option => option.MapFrom(w => w.EndDate));
        CreateMap<Contract, ContractCreateRequest>();
        CreateMap<ContractUpdateRequest, Contract>()
            .ForMember(c => c.DateSigned,
                option => option.MapFrom(w => w.DateSigned))
            .ForMember(c => c.CreatedDate,
                option => option.MapFrom(w => w.StartDate))
            .ForMember(c => c.EndDate,
                option => option.MapFrom(w => w.EndDate));
        CreateMap<Contract, ContractUpdateRequest>();

        CreateMap<ContractFilterRequest, ContractFilter>()
            .ReverseMap();

        CreateMap<MetricContractFilterRequest, MetricContractFilter>()
            .ReverseMap();

        CreateMap<MetricRenterContractFilterRequest, MetricRenterContractFilterRequest>()
            .ReverseMap();

        CreateMap<Contract, ContractBasicDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContractBasicDetailEntity, Contract>()
            .ReverseMap();

        CreateMap<Contract, ContractMeterDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContractMeterDetailEntity, Contract>()
            .ReverseMap();

        CreateMap<Contract, ContactDetailRenterEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContactDetailRenterEntity, Contract>()
            .ReverseMap();
    }

    private void MapArea()
    {
        CreateMap<AreaCreateRequest, Area>()
            .ReverseMap();
        CreateMap<AreaUpdateRequest, Area>()
            .ReverseMap();
        CreateMap<AreaFilterRequest, AreaFilter>()
            .ReverseMap();
        CreateMap<AreaDetailEntity, Area>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Area, AreaDetailEntity>()
            .ReverseMap();
    }

    private void MapRenter()
    {
        CreateMap<RenterCreateRequest, Renter>()
            .ReverseMap();
        CreateMap<RenterUpdateRequest, Renter>().ReverseMap()
            .ReverseMap();

        CreateMap<RenterFilterRequest, RenterFilter>()
            .ReverseMap();

        CreateMap<MetricRenterFilterRequest, MetricRenterFilter>()
            .ReverseMap();

        CreateMap<Renter, RenterProfileEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RenterProfileEntity, Renter>()
            .ReverseMap();

        CreateMap<Renter, RenterBasicDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RenterBasicDetailEntity, Renter>()
            .ReverseMap();

        CreateMap<Renter, RenterDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RenterDetailEntity, Renter>()
            .ReverseMap();
    }

    private void MapEmployee()
    {
        CreateMap<EmployeeCreateRequest, Employee>()
            .ReverseMap();
        CreateMap<EmployeeUpdateRequest, Employee>()
            .ReverseMap();
        CreateMap<EmployeeFilterRequest, EmployeeFilter>()
            .ReverseMap();

        CreateMap<Employee, EmployeeBuildingDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<EmployeeBuildingDetailEntity, Employee>()
            .ReverseMap();

        CreateMap<Employee, EmployeeDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<EmployeeDetailEntity, Employee>()
            .ReverseMap();

        CreateMap<Employee, EmployeeBasicDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<EmployeeBasicDetailEntity, Employee>()
            .ReverseMap();
    }

    private void MapBuilding()
    {
        CreateMap<BuildingCreateRequest, Building>()
            .ReverseMap();
        CreateMap<BuildingUpdateRequest, Building>()
            .ReverseMap();
        CreateMap<BuildingFilterRequest, BuildingFilter>()
            .ReverseMap();

        CreateMap<Building, BuildingContractDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<BuildingContractDetailEntity, Building>()
            .ReverseMap();

        CreateMap<Building, EmployeeBuildingDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<EmployeeBuildingDetailEntity, Building>()
            .ReverseMap();

        CreateMap<Building, BuildingBasicDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<BuildingBasicDetailEntity, Building>()
            .ReverseMap();

        CreateMap<Building, BuildingDetailEntity>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<BuildingDetailEntity, Building>()
            .ReverseMap();
    }

    private void MapWalletAndWalletType()
    {
        /*
        CreateMap<Wallet, WalletDto>()
            .ForMember(c => c.WalletTypeName,
                option => option.MapFrom(w => w.WalletType.WalletTypeName))
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<WalletDto, Wallet>();
        CreateMap<WalletType, WalletTypeDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<WalletTypeDto, WalletType>();
        */

        //TODO : Reimplement wallet view model 

        CreateMap<WalletUpdateRequest, Wallet>();
        CreateMap<MomoRequest, MomoEntity>();
        CreateMap<MomoResponseEntity, MomoResponse>().ReverseMap();
    }

    private void MapNotiAndNotiType()
    {
        CreateMap<NotificationDto, Notification>();

        CreateMap<Notification, NotificationDto>()
            .ForMember(dto => dto.NotificationTypeName,
                option => option.MapFrom(n => n.NotificationType.NotificationTypeName)
            )
            .ForMember(dto => dto.ColorHex,
                option => option.MapFrom(n =>
                    AppUtils.GetActionColorHex((ColorEnum)Enum.ToObject(typeof(ColorEnum), n.ActionStatusColor)))
            );
    }
}