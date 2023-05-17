using Domain.CustomEntities;
using Domain.EntitiesForManagement;

namespace Service.IHelper;

public interface IConditionCheckHelper
{
    // Area
    public Task<Area?> AreaCheck(int? id, CancellationToken token);

    public Task<Building?> BuildingCheck(int? id, CancellationToken token);

    public Task<RepositoryResponse> AreaNameCheck(string? areaName, CancellationToken token);
    public Task<RepositoryResponse> AreaNameCheck(string? areaName, int? areaId, CancellationToken token);

    // Flat

    public Task<Flat?> FlatCheck(int? id, int buildingId, CancellationToken token);

    public Task<FlatType?> FlatTypeCheck(int? id, int buildingId, CancellationToken token);


    // Room

    public Task<Room?> GetRoomInAFlatById(int? roomId, int? flatId, int? buildingId, CancellationToken token);


    // 
    public Task<Employee?> EmployeeCheck(int? id, CancellationToken token);

    public Task<Renter?> RenterCheck(int? id, CancellationToken token);

    public Task<Role?> RoleCheck(int? id, CancellationToken token);

    public Task<RepositoryResponse> RenterUsernameCheck(string? username, CancellationToken token);
    public Task<RepositoryResponse> EmployeeUsernameExist(string? username, CancellationToken token);

    public Task<RepositoryResponse> RenterEmailCheck(string? email, CancellationToken token);

    public Task<RepositoryResponse> RenterEmailCheck(string? email, int? renterId, CancellationToken token);

    public Task<RepositoryResponse> EmployeeEmailCheck(string? email, CancellationToken token);

    public Task<RepositoryResponse> EmployeeEmailCheck(string objEmail, int? employeeId, CancellationToken token);


    public Task<Feedback?> FeedbackCheck(int? id, CancellationToken token);

    public Task<FeedbackType?> FeedbackTypeCheck(int? id, CancellationToken token);


    public Task<ServiceEntity?> ServiceCheck(int? id, CancellationToken token);

    public Task<ServiceType?> ServiceTypeCheck(int? id, CancellationToken token);

    public Task<Invoice?> InvoiceCheck(int? id, CancellationToken token);

    public Task<Contract?> ContractCheck(int? id, CancellationToken token);

    // Ticket check

    public Task<TicketType?> TicketTypeCheck(int? id, CancellationToken token);

    public Task<Ticket?> TicketCheck(int? ticketId, int? renterId, CancellationToken token);
    public Task<Ticket?> TicketCheck(int? ticketId, CancellationToken renterId);


    // Invoice check

    public Task<InvoiceDetail?> InvoiceDetailCheck(int? id, CancellationToken token);

    public Task<InvoiceType?> InvoiceTypeCheck(int? id, CancellationToken token);

    public Task<RoomType?> RoomTypeCheck(int? roomId, int? buildingId, CancellationToken token);

    // Check if exist 
    public Task<RepositoryResponse>
        IsRoomExistAndAvailableInThisFlat(int? roomId, int? flatId, CancellationToken token);

    public Task<RepositoryResponse> IsAnyFlatInUseWithThisType(int? roomId, int? buildingId, CancellationToken token);

    public Task<RepositoryResponse> IsAnyFlatIsInUseWithThisType(int? flatTypeId, int buildingId,
        CancellationToken token);

    public Task<RepositoryResponse> IsFlatTypeNameDuplicate(string? flatTypeName, int buildingId,
        CancellationToken token);
}