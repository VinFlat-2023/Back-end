using Domain.CustomEntities;
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

    public async Task<Employee?> EmployeeCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Employees.GetEmployeeById(id, token);
    }

    public async Task<Renter?> RenterCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Renters.GetRenterById(id, token);
    }

    public async Task<Role?> RoleCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Roles.GetRoleById(id, token);
    }

    public async Task<RepositoryResponse> RenterEmailCheck(string? email, CancellationToken token)
    {
        return await _serviceWrapper.Renters.IsRenterEmailExist(email, token);
    }

    public async Task<RepositoryResponse> RenterEmailCheck(string? email, int? renterId, CancellationToken token)
    {
        return await _serviceWrapper.Renters.IsRenterEmailExist(email, renterId, token);
    }

    public async Task<RepositoryResponse> EmployeeEmailCheck(string? objEmail, int? employeeId, CancellationToken token)
    {
        return await _serviceWrapper.Employees.IsEmployeeEmailExist(objEmail, employeeId, token);
    }

    public async Task<RepositoryResponse> EmployeeEmailCheck(string? email, CancellationToken token)
    {
        return await _serviceWrapper.Employees.IsEmployeeEmailExist(email, token);
    }

    public async Task<RepositoryResponse> EmployeeUsernameExist(string? username, CancellationToken token)
    {
        return await _serviceWrapper.Employees.IsEmployeeUsernameExist(username, token);
    }

    public async Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token)
    {
        return await _serviceWrapper.Renters.RenterUsernameCheck(username, token);
    }

    public async Task<Flat?> FlatCheck(int? id, int buildingId, CancellationToken token)
    {
        return await _serviceWrapper.Flats.GetFlatById(id, buildingId, token);
    }

    public async Task<FlatType?> FlatTypeCheck(int? id, int buildingId, CancellationToken token)
    {
        return await _serviceWrapper.FlatTypes.GetFlatTypeById(id, buildingId, token);
    }

    public async Task<Feedback?> FeedbackCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Feedbacks.GetFeedbackById(id, token);
    }

    public async Task<FeedbackType?> FeedbackTypeCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.FeedbackTypes.GetFeedbackTypeById(id, token);
    }

    public async Task<Building?> BuildingCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Buildings.GetBuildingById(id, token);
    }

    public async Task<ServiceEntity?> ServiceCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.ServicesEntity.GetServiceEntityById(id, token);
    }

    public async Task<ServiceType?> ServiceTypeCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.ServiceTypes.GetServiceTypeById(id, token);
    }

    public async Task<Invoice?> InvoiceCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Invoices.GetInvoiceById(id, token);
    }

    public async Task<Contract?> ContractCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Contracts.GetContractById(id, token);
    }

    public async Task<TicketType?> TicketTypeCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.TicketTypes.GetTicketTypeById(id, token);
    }

    public async Task<Ticket?> TicketCheck(int? ticketId, int? renterId, CancellationToken token)
    {
        return await _serviceWrapper.Tickets.GetTicketById(ticketId, renterId, token);
    }

    public async Task<Ticket?> TicketCheck(int? ticketId, CancellationToken token)
    {
        return await _serviceWrapper.Tickets.GetTicketById(ticketId, token);
    }

    public async Task<InvoiceDetail?> InvoiceDetailCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.InvoiceDetails.GetInvoiceDetailById(id, token);
    }

    public async Task<InvoiceType?> InvoiceTypeCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.InvoiceTypes.GetInvoiceTypeById(id, token);
    }

    public async Task<Area?> AreaCheck(int? id, CancellationToken token)
    {
        return await _serviceWrapper.Areas.GetAreaById(id, token);
    }

    public async Task<RepositoryResponse> AreaNameCheck(string? areaName, CancellationToken token)
    {
        return await _serviceWrapper.Areas.GetAreaByName(areaName, token);
    }

    public async Task<RepositoryResponse> AreaNameCheck(string? areaName, int? areaId, CancellationToken token)
    {
        return await _serviceWrapper.Areas.GetAreaByName(areaName, areaId, token);
    }

    public async Task<Room?> RoomCheck(int? roomId, int? buildingId, CancellationToken token)
    {
        return await _serviceWrapper.Rooms.GetRoomById(roomId, buildingId, token);
    }

    public async Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomId, int? buildingId, CancellationToken token)
    {
        return await _serviceWrapper.Rooms.IsAnyoneRentedCheck(roomId, buildingId, token);
    }

    /*
    public async Task<RoomType?> RoomTypeCheck(int? roomTypeId)
    {
        return await _serviceWrapper.Rooms.get
    }
    */
}