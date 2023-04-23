using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceType;
using Service.IHelper;
using Service.IValidator;

namespace Service.Validator;

public class InvoiceValidator : BaseValidator, IInvoiceValidator
{
    private readonly IConditionCheckHelper _conditionCheckHelper;

    public InvoiceValidator(IConditionCheckHelper conditionCheckHelper)
    {
        _conditionCheckHelper = conditionCheckHelper;
    }

    public async Task<ValidatorResult> ValidateParams(Invoice? obj, int? invoiceId, CancellationToken token)
    {
        try
        {
            if (invoiceId != null)
                switch (obj?.InvoiceId)
                {
                    case not null when obj.InvoiceId != invoiceId:
                        ValidatorResult.Failures.Add("Invoice id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Invoice is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.InvoiceCheck(obj.InvoiceId, token) == null)
                            ValidatorResult.Failures.Add("Invoice provided does not exist");
                        break;
                }

            switch (obj?.EmployeeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Employee is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId, token) == null)
                        ValidatorResult.Failures.Add("Employee provided does not exist");
                    break;
            }

            switch (obj?.RenterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Renter is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId, token) == null)
                        ValidatorResult.Failures.Add("Renter provided does not exist");
                    break;
            }

            switch (obj?.InvoiceTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Invoice type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId, token) == null)
                        ValidatorResult.Failures.Add("Invoice type provided does not exist");
                    break;
            }

            switch (obj?.Name)
            {
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("TicketTypeName cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Invoice name is required");
                    break;
            }

            switch (obj?.TotalAmount)
            {
                case not null when obj.TotalAmount < 0:
                    ValidatorResult.Failures.Add("Invoice amount cannot be negative");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Invoice amount is required");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");

            switch (obj?.Detail)
            {
                case not null when obj.Detail.Length > 500:
                    ValidatorResult.Failures.Add("Invoice detail max length reached");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Detail):
                    ValidatorResult.Failures.Add("Invoice detail is required");
                    break;
            }

            if (obj?.CreatedTime == null)
                ValidatorResult.Failures.Add("Created time is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the invoice");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public Task<ValidatorResult> ValidateParams(InvoiceCreateRequest? invoice, CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(InvoiceUpdateRequest? obj, int? invoiceId,
        CancellationToken token)
    {
        try
        {
            if (await _conditionCheckHelper.InvoiceCheck(invoiceId, token) == null)
                ValidatorResult.Failures.Add("Invoice provided does not exist");

            switch (obj?.Name)
            {
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("TicketTypeName cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Invoice name is required");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");

            switch (obj?.DueDate)
            {
                case not null when obj.DueDate < DateTime.Now:
                    ValidatorResult.Failures.Add("Due date cannot be in the past");
                    break;
                case not null when obj.DueDate > DateTime.Now.AddYears(1):
                    ValidatorResult.Failures.Add("Due date cannot be more than a year in the future");
                    break;
                case null:
                    ValidatorResult.Failures.Add("End date is required");
                    break;
            }

            switch (obj?.Detail)
            {
                case not null when obj.Detail.Length > 500:
                    ValidatorResult.Failures.Add("Invoice detail max length reached");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Detail):
                    ValidatorResult.Failures.Add("Invoice detail is required");
                    break;
            }

            switch (obj?.EmployeeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Employee is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.EmployeeCheck(obj.EmployeeId, token) == null)
                        ValidatorResult.Failures.Add("Employee provided does not exist");
                    break;
            }

            switch (obj?.RenterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Renter is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId, token) == null)
                        ValidatorResult.Failures.Add("Renter provided does not exist");
                    break;
            }

            switch (obj?.InvoiceTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Invoice type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId, token) == null)
                        ValidatorResult.Failures.Add("Invoice type provided does not exist");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the invoice");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(InvoiceDetail? obj, int? invoiceDetailId, CancellationToken token)
    {
        try
        {
            if (invoiceDetailId != null)
                switch (obj?.InvoiceDetailId)
                {
                    case not null when obj.InvoiceDetailId != invoiceDetailId:
                        ValidatorResult.Failures.Add("Invoice detail id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Invoice detail is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.InvoiceDetailCheck(obj.InvoiceDetailId, token) == null)
                            ValidatorResult.Failures.Add("Invoice detail provided does not exist");
                        break;
                }

            switch (obj?.InvoiceId)
            {
                case null:
                    ValidatorResult.Failures.Add("Invoice is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.InvoiceCheck(obj.InvoiceId, token) == null)
                        ValidatorResult.Failures.Add("Invoice provided does not exist");
                    break;
            }

            switch (obj?.Amount)
            {
                case not null when obj.Amount < 0:
                    ValidatorResult.Failures.Add("Invoice detail amount cannot be negative");
                    break;
                case null:
                    ValidatorResult.Failures.Add("Invoice detail amount is required");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the invoice detail");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(InvoiceType? obj, int? invoiceTypeId, CancellationToken token)
    {
        try
        {
            if (invoiceTypeId != null)
                switch (obj?.InvoiceTypeId)
                {
                    case not null when obj?.InvoiceTypeId != invoiceTypeId:
                        ValidatorResult.Failures.Add("Invoice type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Invoice type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.InvoiceTypeCheck(obj.InvoiceTypeId, token) == null)
                            ValidatorResult.Failures.Add("Invoice type provided does not exist");
                        break;
                }

            switch (obj?.InvoiceTypeName)
            {
                case not null when obj.InvoiceTypeName.Length > 100:
                    ValidatorResult.Failures.Add("Invoice type cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.InvoiceTypeName):
                    ValidatorResult.Failures.Add("Invoice type name is required");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the invoice type");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public Task<ValidatorResult> ValidateParams(InvoiceTypeCreateRequest? invoiceType, CancellationToken employeeId)
    {
        throw new NotImplementedException();
    }

    public Task<ValidatorResult> ValidateParams(InvoiceTypeUpdateRequest? invoiceType, int? employeeId,
        CancellationToken token)
    {
        throw new NotImplementedException();
    }

    public async Task<ValidatorResult> ValidateParams(InvoiceCreateRequest? obj, int? employeeId,
        CancellationToken token)
    {
        try
        {
            switch (obj?.Name)
            {
                case not null when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("TicketTypeName cannot exceed 100 characters");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Invoice name is required");
                    break;
            }

            if (obj?.Status == null)
                ValidatorResult.Failures.Add("Status is required");

            switch (obj?.DueDate)
            {
                case not null when obj.DueDate < DateTime.Now:
                    ValidatorResult.Failures.Add("Due date cannot be in the past");
                    break;
                case not null when obj.DueDate > DateTime.Now.AddYears(1):
                    ValidatorResult.Failures.Add("Due date cannot be more than a year in the future");
                    break;
                case null:
                    ValidatorResult.Failures.Add("End date is required");
                    break;
            }

            switch (obj?.Detail)
            {
                case not null when obj.Detail.Length > 500:
                    ValidatorResult.Failures.Add("Invoice detail max length reached");
                    break;
                case not null when string.IsNullOrWhiteSpace(obj.Detail):
                    ValidatorResult.Failures.Add("Invoice detail is required");
                    break;
            }

            switch (obj?.RenterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Renter is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId, token) == null)
                        ValidatorResult.Failures.Add("Renter provided does not exist");
                    break;
            }

            switch (obj?.InvoiceTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Invoice type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId, token) == null)
                        ValidatorResult.Failures.Add("Invoice type provided does not exist");
                    break;
            }
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the invoice");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }
}