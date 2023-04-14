using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Service.Validator;

namespace Service.IValidator;

public interface IInvoiceValidator
{
    Task<ValidatorResult> ValidateParams(Invoice obj, int? invoiceId);
    Task<ValidatorResult> ValidateParams(InvoiceCreateRequest? invoice, int employeeId);
    Task<ValidatorResult> ValidateParams(InvoiceUpdateRequest? invoice, int invoiceId);

    Task<ValidatorResult> ValidateParams(InvoiceDetail obj, int? invoiceDetailId);

    Task<ValidatorResult> ValidateParams(InvoiceType obj, int? invoiceTypeId);
}