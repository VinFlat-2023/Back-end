using Domain.EntitiesForManagement;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class TicketValidator : BaseValidator, ITicketValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public TicketValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Ticket? obj, int? ticketId)
    {
        try
        {
            if (ticketId != null)
                switch (obj?.TicketId)
                {
                    case { } when obj.TicketId != ticketId:
                        ValidatorResult.Failures.Add("Ticket id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Ticket is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.TicketCheck(obj.TicketId) == null)
                            ValidatorResult.Failures.Add("Ticket provided does not exist");
                        break;
                }

            switch (obj?.TicketName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.TicketName):
                    ValidatorResult.Failures.Add("Ticket name is required");
                    break;
                case { } when obj.TicketName.Length > 500:
                    ValidatorResult.Failures.Add("Ticket name cannot exceed 100 characters");
                    break;
            }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Ticket description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Ticket description cannot exceed 500 characters");
                    break;
            }

            if (obj?.CreateDate == null)
                ValidatorResult.Failures.Add("Create date is required");


            switch (obj?.AccountId)
            {
                case null:
                    ValidatorResult.Failures.Add("Management account id is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.AccountCheck(obj.AccountId) == null)
                        ValidatorResult.Failures.Add("Management account provided does not exist");
                    break;
            }

            switch (obj?.Amount)
            {
                case { } when obj.Amount < 0:
                    ValidatorResult.Failures.Add("Invoice detail amount cannot be negative");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Invoice detail amount is required");
                    break;
            }

            switch (obj?.ContractId)
            {
                case { } when obj.ContractId < 0:
                    ValidatorResult.Failures.Add("Contract id cannot be negative");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Contract id is required");
                    break;
            }

            switch (obj?.TicketTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Ticket type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.TicketTypeCheck(obj.TicketTypeId) == null)
                        ValidatorResult.Failures.Add("Ticket type provided does not exist");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Ticket status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the ticketFilterRequest");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(TicketType? obj, int? ticketTypeId)
    {
        try
        {
            if (ticketTypeId != null)
                switch (obj?.TicketTypeId)
                {
                    case { } when obj.TicketTypeId != ticketTypeId:
                        ValidatorResult.Failures.Add("Ticket id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Ticket type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.TicketTypeCheck(obj.TicketTypeId) == null)
                            ValidatorResult.Failures.Add("Ticket type provided does not exist");
                        break;
                }

            switch (obj?.Description)
            {
                case { } when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Ticket type description is required");
                    break;
                case { } when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Ticket type description cannot exceed 500 characters");
                    break;
            }

            switch (obj?.TicketTypeName)
            {
                case { } when string.IsNullOrWhiteSpace(obj.TicketTypeName):
                    ValidatorResult.Failures.Add("Ticket type name is required");
                    break;
                case { } when obj.TicketTypeName.Length > 100:
                    ValidatorResult.Failures.Add("Ticket type name cannot exceed 100 characters");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Ticket type status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the ticketFilterRequest type");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}