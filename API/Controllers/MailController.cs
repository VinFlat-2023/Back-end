using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.IService;

namespace API.Controllers;

[ApiController]
[Route("mail")]
public class MailController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment env;
    private readonly ICustomeMailService mailService;

    private readonly IServiceWrapper serviceWrapper;

    //private readonly IWebHostEnvironment env;
    public MailController( /*ICustomeMailService emailSender,*/ /*IWebHostEnvironment env,*/ IMapper mapper,
        IServiceWrapper serviceWrapper)
    {
        //mailService = emailSender;
        //this.env = env;
        _mapper = mapper;
        this.serviceWrapper = serviceWrapper;
    }


    [HttpGet("paymentReminder")]
    public async Task<IActionResult> SendPaymentReminder()
    {
        //string rootPath = env.WebRootPath;
        var result = await serviceWrapper.Mails.SendPaymentReminderAsync();

        return result ? Ok("Send mail successfully") : BadRequest("Somthing went wrong");
    }

    [HttpPost]
    public async Task<IActionResult> PostManyReceiversWithTemplate([FromForm] List<string> receivers,
        [FromForm] string subject,
        [FromForm] string content, [FromForm] IFormFileCollection attachments)
    {
        //string rootPath = env.WebRootPath;
        //MailMessageEntity mail = new MailMessageEntity( receivers, subject, content, attachments);
        //var result = await mailService.SendEmailWithDefaultTemplateAsync(mail, rootPath);
        var result =
            await serviceWrapper.Mails.SendEmailWithDefaultTemplateAsync(receivers, subject, content,
                attachments /*, rootPath*/);

        return result ? Ok("Send mail successfully") : BadRequest("Somthing went wrong");
    }

    #region Unused Code

    //[HttpGet]
    //public async Task<IActionResult> GetWithTemplate(string receiver, string subject, string content)
    //{
    //    //string rootPath = env.WebRootPath;
    //    var result = await serviceWrapper.Mails.SendEmailWithDefaultTemplateAsync(new string[] { receiver }, subject, content, attachments: null/*, rootPath*/);

    //    return result ? Ok("Send mail successfully") : BadRequest("Somthing went wrong");
    //}
    //[HttpGet]
    //public async Task<IActionResult> GetWithTemplate(string receiver, string subject, string content)
    //{
    //    var rootPath = env.WebRootPath;
    //    var result =
    //        await mailService.SendEmailWithDefaultTemplateAsync(new[] { receiver }, subject, content, null, rootPath);

    //    return result ? Ok("Send mail successfully") : BadRequest("Somthing went wrong");
    //}

    //[HttpPost]
    //public async Task<IActionResult> PostManyReceiversWithTemplate([FromForm] List<string> receivers,
    //    [FromForm] string subject,
    //    [FromForm] string content, [FromForm] IFormFileCollection attachments)
    //{
    //    var rootPath = env.WebRootPath;
    //    //MailMessageEntity mail = new MailMessageEntity( receivers, subject, content, attachments);
    //    //var result = await mailService.SendEmailWithDefaultTemplateAsync(mail, rootPath);
    //    var result =
    //        await mailService.SendEmailWithDefaultTemplateAsync(receivers, subject, content, attachments, rootPath);

    //    return result ? Ok("Send mail successfully") : BadRequest("Somthing went wrong");
    //}

    #endregion
}