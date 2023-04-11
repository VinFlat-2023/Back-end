using Domain.EntitiesForManagement;

namespace Service.IHelper;

public interface IConditionCheckHelper
{
    public Task<Employee?> EmployeeCheck(int? id);

    public Task<Renter?> RenterCheck(int? id);

    public Task<Role?> RoleCheck(int? id);

    public Task<Renter?> RenterUsernameCheck(string? username);

    public Task<Renter?> RenterEmailCheck(string? email);

    public Task<Flat?> FlatCheck(int? id);

    public Task<FlatType?> FlatTypeCheck(int? id);

    public Task<Feedback?> FeedbackCheck(int? id);

    public Task<FeedbackType?> FeedbackTypeCheck(int? id);

    public Task<Building?> BuildingCheck(int? id);

    public Task<ServiceEntity?> ServiceCheck(int? id);

    public Task<ServiceType?> ServiceTypeCheck(int? id);

    public Task<Invoice?> InvoiceCheck(int? id);

    public Task<Contract?> ContractCheck(int? id);

    public Task<TicketType?> TicketTypeCheck(int? id);

    public Task<Ticket?> TicketCheck(int? id);

    public Task<InvoiceDetail?> InvoiceDetailCheck(int? id);

    public Task<InvoiceType?> InvoiceTypeCheck(int? id);

    public Task<Area?> AreaCheck(int? id);

    public Task<Employee?> EmployeeEmailCheck(string? email);

    public Task<Employee?> EmployeeUsernameExist(string? username);

    public Task<Room?> RoomCheck(int? roomId);
}