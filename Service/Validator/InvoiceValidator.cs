using Domain.EntitiesForManagement;
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

    public async Task<ValidatorResult> ValidateParams(Invoice? obj, int? invoiceId)
    {
        try
        {
            if (invoiceId != null)
                switch (obj?.InvoiceId)
                {
                    case { } when obj.InvoiceId != invoiceId:
                        ValidatorResult.Failures.Add("Invoice id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Invoice is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.InvoiceCheck(obj.InvoiceId) == null)
                            ValidatorResult.Failures.Add("Invoice provided does not exist");
                        break;
                }

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

            switch (obj?.RenterId)
            {
                case null:
                    ValidatorResult.Failures.Add("Renter is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                        ValidatorResult.Failures.Add("Renter provided does not exist");
                    break;
            }

            switch (obj?.InvoiceTypeId)
            {
                case null:
                    ValidatorResult.Failures.Add("Invoice type is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.RenterCheck(obj.RenterId) == null)
                        ValidatorResult.Failures.Add("Invoice type provided does not exist");
                    break;
            }

            switch (obj?.Name)
            {
                case { } when obj.Name.Length > 100:
                    ValidatorResult.Failures.Add("TicketTypeName cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Name):
                    ValidatorResult.Failures.Add("Invoice name is required");
                    break;
            }

            switch (obj?.Amount)
            {
                case { } when obj.Amount < 0:
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
                case { } when obj.Detail.Length > 500:
                    ValidatorResult.Failures.Add("Invoice detail max length reached");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.Detail):
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

    public async Task<ValidatorResult> ValidateParams(InvoiceDetail? obj, int? invoiceDetailId)
    {
        try
        {
            if (invoiceDetailId != null)
                switch (obj?.InvoiceDetailId)
                {
                    case { } when obj.InvoiceDetailId != invoiceDetailId:
                        ValidatorResult.Failures.Add("Invoice detail id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Invoice detail is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.InvoiceDetailCheck(obj.InvoiceDetailId) == null)
                            ValidatorResult.Failures.Add("Invoice detail provided does not exist");
                        break;
                }

            switch (obj?.InvoiceId)
            {
                case null:
                    ValidatorResult.Failures.Add("Invoice is required");
                    break;
                case not null:
                    if (await _conditionCheckHelper.InvoiceCheck(obj.InvoiceId) == null)
                        ValidatorResult.Failures.Add("Invoice provided does not exist");
                    break;
            }

            if (obj?.ServiceId != null)
                switch (obj.ServiceId)
                {
                    case null:
                        ValidatorResult.Failures.Add("Service is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.ServiceCheck(obj.ServiceId) == null)
                            ValidatorResult.Failures.Add("Service provided does not exist");
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
        }
        catch (Exception e)
        {
            ValidatorResult.Failures.Add("An error occurred while validating the invoice detail");
            Console.WriteLine(e.Message, e.Data);
        }

        return ValidatorResult;
    }

    public async Task<ValidatorResult> ValidateParams(InvoiceType? obj, int? invoiceTypeId)
    {
        try
        {
            if (invoiceTypeId != null)
                switch (obj?.InvoiceTypeId)
                {
                    case { } when obj?.InvoiceTypeId != invoiceTypeId:
                        ValidatorResult.Failures.Add("Invoice type id mismatch");
                        break;
                    case null:
                        ValidatorResult.Failures.Add("Invoice type is required");
                        break;
                    case not null:
                        if (await _conditionCheckHelper.InvoiceTypeCheck(obj.InvoiceTypeId) == null)
                            ValidatorResult.Failures.Add("Invoice type provided does not exist");
                        break;
                }

            switch (obj?.InvoiceTypeName)
            {
                case { } when obj.InvoiceTypeName.Length > 100:
                    ValidatorResult.Failures.Add("Invoice type cannot exceed 100 characters");
                    break;
                case { } when string.IsNullOrWhiteSpace(obj.InvoiceTypeName):
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
}