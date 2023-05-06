using Domain.CustomEntities;
using Domain.EntitiesForManagement;

namespace Service.IHelper;

public interface IConditionCheckHelper
{
    public Task<Employee?> EmployeeCheck(int? id, CancellationToken token);

    public Task<Renter?> RenterCheck(int? id, CancellationToken token);

    public Task<Role?> RoleCheck(int? id, CancellationToken token);

    public Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token);
    public Task<RepositoryResponse> EmployeeUsernameExist(string? username, CancellationToken token);

    public Task<RepositoryResponse> RenterEmailCheck(string? email, CancellationToken token);

    public Task<RepositoryResponse> RenterEmailCheck(string? email, int? renterId, CancellationToken token);

    public Task<RepositoryResponse> EmployeeEmailCheck(string? email, CancellationToken token);

    public Task<RepositoryResponse> EmployeeEmailCheck(string objEmail, int? employeeId, CancellationToken token);

    public Task<Flat?> FlatCheck(int? id, int buildingId, CancellationToken token);

    public Task<FlatType?> FlatTypeCheck(int? id, int buildingId, CancellationToken token);

    public Task<Feedback?> FeedbackCheck(int? id, CancellationToken token);

    public Task<FeedbackType?> FeedbackTypeCheck(int? id, CancellationToken token);

    public Task<Building?> BuildingCheck(int? id, CancellationToken token);

    public Task<ServiceEntity?> ServiceCheck(int? id, CancellationToken token);

    public Task<ServiceType?> ServiceTypeCheck(int? id, CancellationToken token);

    public Task<Invoice?> InvoiceCheck(int? id, CancellationToken token);

    public Task<Contract?> ContractCheck(int? id, CancellationToken token);

    public Task<TicketType?> TicketTypeCheck(int? id, CancellationToken token);

    public Task<Ticket?> TicketCheck(int? ticketId, int? renterId, CancellationToken token);
    public Task<Ticket?> TicketCheck(int? ticketId, CancellationToken renterId);

    public Task<InvoiceDetail?> InvoiceDetailCheck(int? id, CancellationToken token);

    public Task<InvoiceType?> InvoiceTypeCheck(int? id, CancellationToken token);

    public Task<Area?> AreaCheck(int? id, CancellationToken token);
    public Task<RepositoryResponse> AreaNameCheck(string? areaName, CancellationToken token);
    public Task<RepositoryResponse> AreaNameCheck(string? areaName, int? areaId, CancellationToken token);
    public Task<Room?> RoomCheck(int? roomId, int? buildingId, CancellationToken token);
    public Task<RepositoryResponse> IsAnyoneRentedCheck(int? roomId, int? buildingId, CancellationToken token);
}