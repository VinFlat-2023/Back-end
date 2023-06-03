using Domain.ControllerEntities;
using Domain.CustomEntities.MomoEntities;
using Microsoft.AspNetCore.Http;

namespace Service.IService;

public interface ICustomerMailService
{
    public Task<bool> SendEmailWithDefaultTemplateAsync(IEnumerable<string> receivers, string subject, string content,
        IFormFileCollection attachments);

    public Task<bool> SendPaymentReminderAsync(int buildingId, CancellationToken token);
    public Task<bool> SendListOfUnPaidRenterToSupervisor(int buildingId, CancellationToken token);
    public Task<bool> SendPaymentConfirmAsync(MomoResponseEntity momo, CancellationToken token);
    public Task<bool> SendResetPasswordEmail(EmailResetPasswordRequest resetPassword, CancellationToken token);

    #region unsued code

    //public Task<bool> SendEmailWithDefaultTemplateAsync(MailMessageEntity mail);
    //bool SendSimpleMail(MailMessageEntity message);
    //bool SendSimpleMail(IEnumerable<string> receivers, string subject, string content, IFormFileCollection attachments);
    //Task<bool> SendSimpleEmailAsync(MailMessageEntity message);
    //Task<bool> SendSimpleMailAsync(IEnumerable<string> receivers, string subject, string content, IFormFileCollection attachments);

    #endregion
}