using Domain.EntityRequest.Ticket;
using Domain.EntityRequest.TicketType;
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

    /*
    public async Task<ValidatorResult> ValidateParams(Ticket? obj, int? ticketId)
    {
        try
        {
            if (ticketId != null)
                switch (obj?.TicketId)
                {
                    case not null when obj.TicketId != ticketId:
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

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Ticket description is required");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Ticket description cannot exceed 500 characters");
                    break;
            }

            if (obj?.CreateDate == null)
                ValidatorResult.Failures.Add("Create date is required");

            switch (obj?.Amount)
            {
                case not null when obj.Amount < 0:
                    ValidatorResult.Failures.Add("Invoice detail amount cannot be negative");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Invoice detail amount is required");
                    break;
            }

            if (ticketId == null)
                switch (obj?.ContractId)
                {
                    case not null when obj.ContractId < 0:
                        ValidatorResult.Failures.Add("Contract id cannot be negative");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Contract id is required");
                        break;
                }

            if (ticketId == null)
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

            if (ticketId == null)
                switch (obj?.EmployeeId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Employee is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId) == null)
                            ValidatorResult.Failures.Add("Employee provided does not exist");
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
                    case not null when obj.TicketTypeId != ticketTypeId:
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
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Ticket type description is required");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Ticket type description cannot exceed 500 characters");
                    break;
            }

            switch (obj?.TicketTypeName)
            {
                case not null when string.IsNullOrWhiteSpace(obj.TicketTypeName):
                    ValidatorResult.Failures.Add("Ticket type name is required");
                    break;
                case not null when obj.TicketTypeName.Length > 100:
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
    */

    public async Task<ValidatorResult> ValidateParams(TicketCreateRequest? obj, CancellationToken token)
    {
        try
        {
            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Mô tả yêu cầu không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Mô tả không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.TicketTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại yêu cầu không được để trống");
                    break;
                case not null when await _conditionCheckHelper.TicketTypeCheck(obj.TicketTypeId, token) == null:
                    ValidatorResult.Failures.Add("Loại yêu cầu không tồn tại");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the ticket");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(TicketUpdateRequest? obj, int? ticketId, CancellationToken token)
    {
        try
        {
            if (obj == null)
                ValidatorResult.Failures.Add("Thông tin ticket không được để trống");
            if (ticketId == null)
                ValidatorResult.Failures.Add("Ticket không tồn tại");
            switch (ticketId)
            {
                case null:
                    ValidatorResult.Failures.Add("Ticket không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.TicketCheck(ticketId, token) == null)
                        ValidatorResult.Failures.Add("Ticket của người thuê trọ này không tồn tại");
                    break;
            }

            switch (obj?.Description)
            {
                case not null when string.IsNullOrWhiteSpace(obj.Description):
                    ValidatorResult.Failures.Add("Mô tả yêu cầu không được để trống");
                    break;
                case not null when obj.Description.Length > 500:
                    ValidatorResult.Failures.Add("Mô tả không được vượt quá 500 ký tự");
                    break;
            }

            switch (obj?.TicketTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Loại yêu cầu không được để trống");
                    break;
                case not null when await _conditionCheckHelper.TicketTypeCheck(obj.TicketTypeId, token) == null:
                    ValidatorResult.Failures.Add("Loại yêu cầu không tồn tại");
                    break;
            }

            switch (obj?.Amount)
            {
                case not null when obj.Amount < 0:
                    ValidatorResult.Failures.Add("Số lượng / thành tiền không được nhỏ hơn 0");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Số lượng / thành tiền không được để trống");
                    break;
            }

            switch (obj?.EmployeeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Nhân viên không được để trống");
                    break;
                case not null:
                    if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId, token) == null)
                        ValidatorResult.Failures.Add("Tài khoản nhân viên không tồn tại");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Tình trạng của phiếu không được để trống");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the ticketFilterRequest");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public Task<ValidatorResult> ValidateParams(TicketTypeCreateRequest? ticketTypeCreateRequest,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }
}