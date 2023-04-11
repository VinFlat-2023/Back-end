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

    public async Task<Employee?> EmployeeCheck(int? id)
    {
        return await _serviceWrapper.Employees.GetEmployeeById(id);
    }

    public async Task<Renter?> RenterCheck(int? id)
    {
        return await _serviceWrapper.Renters.GetRenterById(id);
    }

    public async Task<Role?> RoleCheck(int? id)
    {
        return await _serviceWrapper.Roles.GetRoleById(id);
    }

    public async Task<Renter?> RenterEmailCheck(string? email)
    {
        return await _serviceWrapper.Renters.RenterEmailCheck(email);
    }

    public async Task<Renter?> RenterUsernameCheck(string? username)
    {
        return await _serviceWrapper.Renters.RenterUsernameCheck(username);
    }

    public async Task<Flat?> FlatCheck(int? id)
    {
        return await _serviceWrapper.Flats.GetFlatById(id);
    }

    public async Task<FlatType?> FlatTypeCheck(int? id)
    {
        return await _serviceWrapper.FlatTypes.GetFlatTypeById(id);
    }

    public async Task<Feedback?> FeedbackCheck(int? id)
    {
        return await _serviceWrapper.Feedbacks.GetFeedbackById(id);
    }

    public async Task<FeedbackType?> FeedbackTypeCheck(int? id)
    {
        return await _serviceWrapper.FeedbackTypes.GetFeedbackTypeById(id);
    }

    public async Task<Building?> BuildingCheck(int? id)
    {
        return await _serviceWrapper.Buildings.GetBuildingById(id);
    }

    public async Task<ServiceEntity?> ServiceCheck(int? id)
    {
        return await _serviceWrapper.ServicesEntity.GetServiceEntityById(id);
    }

    public async Task<ServiceType?> ServiceTypeCheck(int? id)
    {
        return await _serviceWrapper.ServiceTypes.GetServiceTypeById(id);
    }

    public async Task<Invoice?> InvoiceCheck(int? id)
    {
        return await _serviceWrapper.Invoices.GetInvoiceById(id);
    }

    public async Task<Contract?> ContractCheck(int? id)
    {
        return await _serviceWrapper.Contracts.GetContractById(id);
    }

    public async Task<TicketType?> TicketTypeCheck(int? id)
    {
        return await _serviceWrapper.TicketTypes.GetTicketTypeById(id);
    }

    public async Task<Ticket?> TicketCheck(int? id)
    {
        return await _serviceWrapper.Tickets.GetTicketById(id);
    }

    public async Task<InvoiceDetail?> InvoiceDetailCheck(int? id)
    {
        return await _serviceWrapper.InvoiceDetails.GetInvoiceDetailById(id);
    }

    public async Task<InvoiceType?> InvoiceTypeCheck(int? id)
    {
        return await _serviceWrapper.InvoiceTypes.GetInvoiceTypeById(id);
    }

    public async Task<Area?> AreaCheck(int? id)
    {
        return await _serviceWrapper.Areas.GetAreaById(id);
    }

    public async Task<Employee?> EmployeeUsernameExist(string? username)
    {
        return await _serviceWrapper.Employees.IsEmployeeUsernameExist(username);
    }

    public async Task<Room?> RoomCheck(int? roomId)
    {
        return await _serviceWrapper.Rooms.GetRoomById(roomId);
    }

    /*
    public async Task<RoomType?> RoomTypeCheck(int? roomTypeId)
    {
        return await _serviceWrapper.Rooms.get
    }
    */

    public async Task<Employee?> EmployeeEmailCheck(string? email)
    {
        return await _serviceWrapper.Employees.IsEmployeeEmailExist(email);
    }
}