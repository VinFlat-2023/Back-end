using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface ITicketValidator
{
    Task<ValidatorResult> ValidateParams(Ticket? obj, int? ticketId);

    Task<ValidatorResult> ValidateParams(TicketType? obj, int? ticketTypeId);
}