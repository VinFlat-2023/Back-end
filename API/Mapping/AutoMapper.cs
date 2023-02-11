using AutoMapper;
using Domain.CustomEntities.Mail;
using Domain.CustomEntities.MomoEntities;
using Domain.EntitiesDTO.AccountDTO;
using Domain.EntitiesDTO.AreaDTO;
using Domain.EntitiesDTO.BuildingDTO;
using Domain.EntitiesDTO.ContractDTO;
using Domain.EntitiesDTO.ContractHistoryDTO;
using Domain.EntitiesDTO.FeedbackDTO;
using Domain.EntitiesDTO.FeedbackTypeDTO;
using Domain.EntitiesDTO.FlatDTO;
using Domain.EntitiesDTO.FlatTypeDTO;
using Domain.EntitiesDTO.InvoiceDetailDTO;
using Domain.EntitiesDTO.InvoiceDTO;
using Domain.EntitiesDTO.InvoiceTypeDTO;
using Domain.EntitiesDTO.MailMessageDTO;
using Domain.EntitiesDTO.MajorDTO;
using Domain.EntitiesDTO.NotificationDTO;
using Domain.EntitiesDTO.RenterDTO;
using Domain.EntitiesDTO.RoleDTO;
using Domain.EntitiesDTO.ServiceDTO;
using Domain.EntitiesDTO.ServiceTypeDTO;
using Domain.EntitiesDTO.TicketDTO;
using Domain.EntitiesDTO.TicketTypeDTO;
using Domain.EntitiesDTO.UniversityDTO;
using Domain.EntitiesDTO.WalletDTO;
using Domain.EntitiesDTO.WalletTypeDTO;
using Domain.EntitiesForManagement;
using Domain.EntityRequest.Account;
using Domain.EntityRequest.Area;
using Domain.EntityRequest.Building;
using Domain.EntityRequest.Contract;
using Domain.EntityRequest.ContractHistory;
using Domain.EntityRequest.FeedBack;
using Domain.EntityRequest.FeedbackType;
using Domain.EntityRequest.Flat;
using Domain.EntityRequest.FlatType;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceDetail;
using Domain.EntityRequest.InvoiceType;
using Domain.EntityRequest.Major;
using Domain.EntityRequest.Renter;
using Domain.EntityRequest.Role;
using Domain.EntityRequest.Service;
using Domain.EntityRequest.ServiceType;
using Domain.EntityRequest.Ticket;
using Domain.EntityRequest.TicketType;
using Domain.EntityRequest.University;
using Domain.EntityRequest.Wallet;
using Domain.EnumEntities;
using Domain.FilterRequests;
using Domain.QueryFilter;
using Domain.Responses;
using Domain.Utils;
using MimeKit;

namespace API.Mapping;

public class AutoMapper : Profile
{
    public AutoMapper()
    {
        // Basic DTOs
        MapAccount();
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
        MapMajor();
        MapRenter();
        MapRequest();
        MapRequestType();
        MapRole();
        MapService();
        MapServiceType();
        MapUniversity();
        MapWalletAndWalletType();
        MapMail();
        MapNotiAndNotiType();
    }

    private void MapInvoiceType()
    {
        CreateMap<InvoiceType, InvoiceTypeDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<InvoiceTypeDto, InvoiceType>()
            .ReverseMap();
        CreateMap<InvoiceTypeCreateRequest, InvoiceType>()
            .ReverseMap();
        CreateMap<InvoiceTypeUpdateRequest, InvoiceType>()
            .ReverseMap();
        CreateMap<InvoiceTypeFilterRequest, InvoiceTypeFilter>()
            .ReverseMap();
    }

    private void MapInvoiceDetail()
    {
        CreateMap<InvoiceDetail, InvoiceDetailDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<InvoiceDetailDto, InvoiceDetail>()
            .ReverseMap();
        CreateMap<InvoiceDetailCreateRequest, InvoiceDetail>()
            .ReverseMap();
        CreateMap<InvoiceDetailUpdateRequest, InvoiceDetail>()
            .ReverseMap();
        CreateMap<InvoiceDetailFilterRequest, InvoiceDetailFilter>()
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

    private void MapUniversity()
    {
        CreateMap<University, UniversityDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<UniversityDto, University>()
            .ReverseMap();
        CreateMap<UniversityCreateRequest, University>()
            .ReverseMap();
        CreateMap<UniversityUpdateRequest, University>()
            .ReverseMap();
        CreateMap<UniversityFilterRequest, UniversityFilter>()
            .ReverseMap();
    }

    private void MapServiceType()
    {
        CreateMap<ServiceType, ServiceTypeDto>()
            .ForMember(
                o => o.ServiceTypeId,
                opt => opt.MapFrom(src => src.ServiceEntities)
            )
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ServiceTypeDto, ServiceType>()
            .ReverseMap();
        CreateMap<ServiceTypeCreateRequest, ServiceType>()
            .ReverseMap();
        CreateMap<ServiceTypeUpdateRequest, ServiceType>()
            .ReverseMap();
        CreateMap<ServiceTypeFilterRequest, ServiceTypeFilter>()
            .ReverseMap();
    }

    private void MapService()
    {
        CreateMap<ServiceEntity, ServiceEntityDto>()
            .ForMember(
                o => o.ServiceId,
                opt => opt.MapFrom(src => src.ServiceId)
            )
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ServiceEntityDto, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceCreateRequest, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceUpdateRequest, ServiceEntity>()
            .ReverseMap();
        CreateMap<ServiceFilterRequest, ServiceEntityFilter>()
            .ReverseMap();
    }

    private void MapRole()
    {
        CreateMap<Role, RoleDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RoleDto, Role>()
            .ReverseMap();
        CreateMap<RoleCreateRequest, Role>()
            .ReverseMap();
        CreateMap<RoleUpdateRequest, Role>()
            .ReverseMap();
        CreateMap<RoleFilterRequest, RoleFilter>()
            .ReverseMap();
    }

    private void MapRequestType()
    {
        CreateMap<TicketType, TicketTypeDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<TicketTypeDto, TicketType>()
            .ReverseMap();
        CreateMap<TicketTypeCreateRequest, TicketType>()
            .ReverseMap();
        CreateMap<TicketTypeUpdateRequest, TicketType>()
            .ReverseMap();
        CreateMap<TicketTypeFilterRequest, TicketTypeFilter>()
            .ReverseMap();
    }

    private void MapRequest()
    {
        CreateMap<Ticket, TicketDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<TicketDto, Ticket>()
            .ReverseMap();
        CreateMap<TicketCreateRequest, Ticket>()
            .ReverseMap();
        CreateMap<TicketUpdateRequest, Ticket>()
            .ReverseMap();
        CreateMap<TicketFilterRequest, TicketFilter>()
            .ReverseMap();
    }

    private void MapMajor()
    {
        CreateMap<Major, MajorDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<MajorDto, Major>()
            .ReverseMap();
        CreateMap<MajorCreateRequest, Major>()
            .ReverseMap();
        CreateMap<MajorUpdateRequest, Major>()
            .ReverseMap();
        CreateMap<MajorFilterRequest, MajorFilter>()
            .ReverseMap();
    }

    private void MapInvoice()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<InvoiceDto, Invoice>()
            .ReverseMap();
        CreateMap<InvoiceCreateRequest, Invoice>()
            .ReverseMap();
        CreateMap<InvoiceUpdateRequest, Invoice>()
            .ReverseMap();
        CreateMap<InvoiceFilterRequest, InvoiceFilter>()
            .ReverseMap();
    }

    private void MapFlatType()
    {
        CreateMap<FlatType, FlatTypeDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FlatTypeDto, FlatType>()
            .ReverseMap();
        CreateMap<FlatTypeCreateRequest, FlatType>()
            .ReverseMap();
        CreateMap<FlatTypeUpdateRequest, FlatType>()
            .ReverseMap();
        CreateMap<FlatTypeFilterRequest, FlatTypeFilter>();
    }

    private void MapFlat()
    {
        CreateMap<Flat, FlatDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FlatDto, Flat>()
            .ReverseMap();
        CreateMap<FlatCreateRequest, Flat>()
            .ReverseMap();
        CreateMap<FlatUpdateRequest, Flat>()
            .ReverseMap();
        CreateMap<FlatFilterRequest, FlatFilter>()
            .ReverseMap();
    }

    private void MapFeedbackType()
    {
        CreateMap<FeedbackType, FeedbackTypeDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FeedbackTypeDto, FeedbackType>()
            .ReverseMap();
        CreateMap<FeedbackTypeCreateRequest, FeedbackType>()
            .ReverseMap();
        CreateMap<FeedbackTypeUpdateRequest, FeedbackType>()
            .ReverseMap();
        CreateMap<FeedbackTypeFilterRequest, FeedbackTypeFilter>()
            .ReverseMap();
    }

    private void MapFeedback()
    {
        CreateMap<Feedback, FeedbackDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<FeedbackDto, Feedback>()
            .ReverseMap();
        CreateMap<FeedbackCreateRequest, Feedback>()
            .ReverseMap();
        CreateMap<FeedbackUpdateRequest, Feedback>()
            .ReverseMap();
        CreateMap<FeedbackFilterRequest, FeedbackFilter>()
            .ReverseMap();
    }

    private void MapContractHistory()
    {
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
    }

    private void MapContract()
    {
        CreateMap<Contract, ContractDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<ContractDto, Contract>()
            .ReverseMap();
        CreateMap<ContractCreateRequest, Contract>()
            .ReverseMap();
        CreateMap<ContractUpdateRequest, Contract>()
            .ReverseMap();
        CreateMap<ContractFilterRequest, ContractFilter>()
            .ReverseMap();
    }

    private void MapArea()
    {
        CreateMap<Area, AreaDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<AreaDto, Area>()
            .ReverseMap();
        CreateMap<AreaCreateRequest, Area>()
            .ReverseMap();
        CreateMap<AreaUpdateRequest, Area>()
            .ReverseMap();
        CreateMap<AreaFilterRequest, AreaFilter>()
            .ReverseMap();
    }

    private void MapRenter()
    {
        CreateMap<Renter, RenterDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<RenterDto, Renter>()
            .ReverseMap();
        CreateMap<RenterCreateRequest, Renter>()
            .ReverseMap();
        CreateMap<RenterUpdateRequest, Renter>().ReverseMap()
            .ReverseMap();
        CreateMap<RenterFilterRequest, RenterFilter>()
            .ReverseMap();
    }

    private void MapAccount()
    {
        CreateMap<Account, AccountDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<AccountDto, Account>()
            .ReverseMap();
        CreateMap<AccountCreateRequest, Account>()
            .ReverseMap();
        CreateMap<AccountUpdateRequest, Account>()
            .ReverseMap();
        CreateMap<AccountFilterRequest, AccountFilter>()
            .ReverseMap();
    }

    private void MapBuilding()
    {
        CreateMap<Building, BuildingDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<BuildingDto, Building>()
            .ReverseMap();
        CreateMap<BuildingCreateRequest, Building>()
            .ReverseMap();
        CreateMap<BuildingUpdateRequest, Building>()
            .ReverseMap();
        CreateMap<BuildingFilterRequest, BuildingFilter>()
            .ReverseMap();
    }

    private void MapWalletAndWalletType()
    {
        CreateMap<Wallet, WalletDto>()
            .ForMember(c => c.WalletTypeName,
                option => option.MapFrom(w => w.WalletType.WalletTypeName))
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<WalletDto, Wallet>();
        CreateMap<WalletType, WalletTypeDto>()
            .ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<WalletTypeDto, WalletType>();
        CreateMap<WalletUpdateRequest, Wallet>();
        CreateMap<MomoRequest, MomoEntity>();
        CreateMap<MomoResponseEntity, MomoResponse>().ReverseMap();
    }

    private void MapNotiAndNotiType()
    {
        CreateMap<NotificationDTO, Notification>();

        CreateMap<Notification, NotificationDTO>()
            .ForMember(dto => dto.NotificationTypeName,
                option => option.MapFrom(n => n.NotificationType.NotificationTypeName)
            )
            .ForMember(dto => dto.ColorHex,
                option => option.MapFrom(n =>
                    AppUtils.GetActionColorHex((ColorEnum)Enum.ToObject(typeof(ColorEnum), n.ActionStatusColor)))
            );
    }
}