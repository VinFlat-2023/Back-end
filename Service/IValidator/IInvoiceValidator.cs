using Domain.EntitiesForManagement;
using Domain.EntityRequest.Invoice;
using Domain.EntityRequest.InvoiceType;
using Service.Validator;

namespace Service.IValidator;

public interface IInvoiceValidator
{
    Task<ValidatorResult> ValidateParams(Invoice obj, int? invoiceId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(InvoiceCreateRequest? invoice, CancellationToken token);
    Task<ValidatorResult> ValidateParams(InvoiceUpdateRequest? invoice, int? invoiceId, CancellationToken token);

    Task<ValidatorResult> ValidateParams(InvoiceDetail? obj, int? invoiceDetailId, CancellationToken token);

    Task<ValidatorResult> ValidateParams(InvoiceType? obj, int? invoiceTypeId, CancellationToken token);
    Task<ValidatorResult> ValidateParams(InvoiceTypeCreateRequest? invoiceType, CancellationToken employeeId);

    Task<ValidatorResult> ValidateParams(InvoiceTypeUpdateRequest? invoiceType, int? employeeId,
        CancellationToken token);
}