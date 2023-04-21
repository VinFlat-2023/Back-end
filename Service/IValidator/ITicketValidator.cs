using Domain.EntityRequest.Ticket;
using Service.Validator;

namespace Service.IValidator;

public interface ITicketValidator
{
    // Task<ValidatorResult> ValidateParams(Ticket? obj, int? ticketId);

    // Task<ValidatorResult> ValidateParams(TicketType? obj, int? ticketTypeId);
    Task<ValidatorResult> ValidateParams(TicketCreateRequest? ticketTypeCreateRequestType, CancellationToken token);

    Task<ValidatorResult> ValidateParams(TicketUpdateRequest? ticketUpdateRequest, int? ticketId,
        CancellationToken token);
}