using Domain.EntityRequest.Renter;
using Service.Validator;

namespace Service.IValidator;

public interface IRenterValidator
{
    Task<ValidatorResult> ValidateParams(RenterUpdateRequest? renter, int? renterId, CancellationToken token);
}