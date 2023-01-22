using Domain.CustomEntities.MomoEntities;
using Microsoft.AspNetCore.Http;

namespace Service.IService;

public interface ICustomeMailService
{
    public Task<bool> SendEmailWithDefaultTemplateAsync(IEnumerable<string> receivers, string subject, string content,
        IFormFileCollection attachments);

    public Task<bool> SendPaymentReminderAsync();
    public Task<bool> SendPaymentConfirmAsync(MomoResponseEntity momo);

    #region unsued code

    //public Task<bool> SendEmailWithDefaultTemplateAsync(MailMessageEntity mail);
    //bool SendSimpleMail(MailMessageEntity message);
    //bool SendSimpleMail(IEnumerable<string> receivers, string subject, string content, IFormFileCollection attachments);
    //Task<bool> SendSimpleEmailAsync(MailMessageEntity message);
    //Task<bool> SendSimpleMailAsync(IEnumerable<string> receivers, string subject, string content, IFormFileCollection attachments);

    #endregion
}