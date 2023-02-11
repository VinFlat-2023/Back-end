using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface ITicketValidator
{
    Task<ValidatorResult> ValidateParams(Ticket? obj, int? TicketId);

    Task<ValidatorResult> ValidateParams(TicketType? obj, int? TicketTypeId);
}