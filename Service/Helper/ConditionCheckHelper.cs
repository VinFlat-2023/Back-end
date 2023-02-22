using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IService;

namespace Service.Helper;

public class ConditionCheckHelper : IConditionCheckHelper
{
    private readonly IServiceWrapper _serviceWrapper;

    public ConditionCheckHelper(IServiceWrapper serviceWrapper)
    {
        _serviceWrapper = serviceWrapper;
    }

    public async Task<Account?> AccountCheck(int? id)
    {
        return await _serviceWrapper.Accounts.GetAccountById(id) ?? null;
    }

    public async Task<Renter?> RenterCheck(int? id)
    {
        return await _serviceWrapper.Renters.GetRenterById(id) ?? null;
    }

    public async Task<Role?> RoleCheck(int? id)
    {
        return await _serviceWrapper.Roles.GetRoleById(id) ?? null;
    }

    public async Task<Major?> MajorCheck(int? id)
    {
        return await _serviceWrapper.Majors.GetMajorById(id) ?? null;
    }

    public async Task<University?> UniversityCheck(int? id)
    {
        return await _serviceWrapper.Universities.GetUniversityById(id) ?? null;
    }

    public async Task<Renter?> RenterEmailCheck(string? email)
    {
        return await _serviceWrapper.Renters.RenterEmailCheck(email) ?? null;
    }

    public async Task<Renter?> RenterUsernameCheck(string? username)
    {
        return await _serviceWrapper.Renters.RenterUsernameCheck(username) ?? null;
    }


    public async Task<Flat?> FlatCheck(int? id)
    {
        return await _serviceWrapper.Flats.GetFlatById(id) ?? null;
    }

    public async Task<FlatType?> FlatTypeCheck(int id)
    {
        return await _serviceWrapper.FlatTypes.GetFlatTypeById(id) ?? null;
    }

    public async Task<Feedback?> FeedbackCheck(int? id)
    {
        return await _serviceWrapper.Feedbacks.GetFeedbackById(id) ?? null;
    }

    public async Task<FeedbackType?> FeedbackTypeCheck(int id)
    {
        return await _serviceWrapper.FeedbackTypes.GetFeedbackTypeById(id) ?? null;
    }

    public async Task<Building?> BuildingCheck(int? id)
    {
        return await _serviceWrapper.Buildings.GetBuildingById(id) ?? null;
    }

    public async Task<ServiceEntity?> ServiceCheck(int? id)
    {
        return await _serviceWrapper.ServicesEntity.GetServiceEntityById(id) ?? null;
    }

    public async Task<ServiceType?> ServiceTypeCheck(int? id)
    {
        return await _serviceWrapper.ServiceTypes.GetServiceTypeById(id) ?? null;
    }

    public async Task<Invoice?> InvoiceCheck(int id)
    {
        return await _serviceWrapper.Invoices.GetInvoiceById(id) ?? null;
    }

    public async Task<Contract?> ContractCheck(int id)
    {
        return await _serviceWrapper.Contracts.GetContractById(id) ?? null;
    }

    public async Task<TicketType?> TicketTypeCheck(int? id)
    {
        return await _serviceWrapper.TicketTypes.GetTicketTypeById(id) ?? null;
    }

    public async Task<Ticket?> TicketCheck(int? id)
    {
        return await _serviceWrapper.Tickets.GetTicketById(id) ?? null;
    }

    public async Task<InvoiceDetail?> InvoiceDetailCheck(int? id)
    {
        return await _serviceWrapper.InvoiceDetails.GetInvoiceDetailById(id) ?? null;
    }

    public async Task<InvoiceType?> InvoiceTypeCheck(int id)
    {
        return await _serviceWrapper.InvoiceTypes.GetInvoiceTypeById(id) ?? null;
    }

    public async Task<Area?> AreaCheck(int? id)
    {
        return await _serviceWrapper.Areas.GetAreaById(id) ?? null;
    }

    public async Task<Account?> AccountUsernameExist(string? username)
    {
        return await _serviceWrapper.Accounts.IsAccountUsernameExist(username) ?? null;
    }

    public async Task<Room?> RoomCheck(int? roomId)
    {
        return await _serviceWrapper.Rooms.GetRoomById(roomId) ?? null;
    }

    public async Task<Account?> AccountEmailCheck(string? email)
    {
        return await _serviceWrapper.Accounts.IsAccountEmailExist(email) ?? null;
    }
}