using Domain.EntitiesForManagement;
using Service.Validator;

namespace Service.IValidator;

public interface IInvoiceValidator
{
    Task<ValidatorResult> ValidateParams(Invoice obj, int? invoiceId);

    Task<ValidatorResult> ValidateParams(InvoiceDetail obj, int? invoiceDetailId);

    Task<ValidatorResult> ValidateParams(InvoiceType obj, int? invoiceTypeId);
}