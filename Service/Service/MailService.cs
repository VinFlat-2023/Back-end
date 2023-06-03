using System.ComponentModel;
using System.Text;
using Application.IRepository;
using AutoMapper;
using Domain.ControllerEntities;
using Domain.CustomEntities.Mail;
using Domain.CustomEntities.MomoEntities;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Domain.ViewModel.InvoiceEntity;
using Domain.ViewModel.RenterEntity;
using Google.Apis.Util;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Utils;
using Service.IService;
using Utilities.Extensions;

//using System.Net.Mail;

namespace Service.Service;

public class CustomerMailService : ICustomerMailService
{
    /// <summary>
    ///     The default Email Template. {0}: email content
    /// </summary>
    private const string DefaultTemplate = "<h2 style='color:red;'>{0}</h2>";

    private readonly MailConfiguration _emailConfig;

    private readonly IMapper _mapper;

    private readonly IRepositoryWrapper _repositories;


    //private readonly IWebHostEnvironment env;
    private readonly string rootPath;

    public CustomerMailService(IWebHostEnvironment env, MailConfiguration emailConfig, IRepositoryWrapper repositories,
        IMapper mapper)
    {
        _emailConfig = emailConfig;
        //this.env = env;
        rootPath = env.WebRootPath;
        _repositories = repositories;
        _mapper = mapper;
    }

    public async Task<bool> SendPaymentReminderAsync(int buildingId, CancellationToken token)
    {
        var unpaidInvoices =
            await _repositories.Invoices.GetUnpaidInvoice(buildingId, token);

        if (!unpaidInvoices.Any())
            return false;

        var mimeMessages =
            await CreatePaymentReminderMimeMessage(unpaidInvoices);

        if (mimeMessages.Count == 0)
            return false;

        foreach (var mimeMessage in mimeMessages)
            try
            {
                await SendAsync(mimeMessage);
            }
            catch
            {
                Console.WriteLine("Failed to send email to this user");
            }

        return false;
    }

    public async Task<bool> SendResetPasswordEmail(EmailResetPasswordRequest resetPassword, CancellationToken token)
    {
        var emailResetPassword = await SendResetPasswordAsync(resetPassword, token);

        if (emailResetPassword.Count == 0)
            return false;

        foreach (var mimeMessage in emailResetPassword)
            try
            {
                await SendAsync(mimeMessage);
            }
            catch
            {
                Console.WriteLine("Failed to send email to this user");
            }

        return true;
    }

    public async Task<bool> SendListOfUnPaidRenterToSupervisor(int buildingId, CancellationToken token)
    {
        var unpaidInvoices =
            await _repositories.Invoices.GetUnpaidInvoice(buildingId, token);

        if (!unpaidInvoices.Any())
            return false;

        var mimeMessagesForSupervisor =
            await CreateListOfUnpaidInvoiceWithRenterName(buildingId, unpaidInvoices, token);

        if (mimeMessagesForSupervisor.Count == 0)
            return false;
        foreach (var mimeMessage in mimeMessagesForSupervisor)
            await SendAsync(mimeMessage);
        return true;
    }

    public async Task<bool> SendEmailWithDefaultTemplateAsync(IEnumerable<string> receivers, string subject,
        string content, IFormFileCollection attachments)
    {
        var message = new MailMessageEntity(receivers, subject, content, attachments);
        var mimeMessages =
            CreateMimeMessageWithSimpleTemplateList(message /*, rootPath*/);

        if (mimeMessages.Count == 0)
            return false;

        foreach (var mimeMessage in mimeMessages)
            await SendAsync(mimeMessage);

        return true;
    }

    public async Task<bool> SendPaymentConfirmAsync(MomoResponseEntity momo, CancellationToken token)
    {
        var paidInvoiceId = int.Parse(momo.OrderId);
        var paid = await _repositories.Invoices.GetInvoiceIncludeRenter(paidInvoiceId, token);
        return true;
    }

    private List<MimeMessage> CreateMimeMessageWithSimpleTemplateList(MailMessageEntity message)
    {
        var list = new List<MimeMessage>();
        //var templatePath = rootPath + Path.DirectorySeparatorChar + MailTemplateHelper.FOLDER +
        //                   Path.DirectorySeparatorChar + MailTemplateHelper.DEFAULT_TEMPLATE_FILE;
        var template = MailTemplateHelper.DEFAULT_TEMPLATE(rootPath);
        var logoPath = rootPath + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar +
                       "logowhite.png";
        foreach (var receiver in message.Receivers)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(_emailConfig.From));
            mimeMessage.To.Add(receiver);
            mimeMessage.Subject = message.Subject;


            var bodyBuilder = new BodyBuilder();
            try
            {
                var email = receiver.Address;
                //<!--{0} is logo-->
                //<!--{1} is username-->
                //<!--{2} is content-->
                //bodyBuilder = new BodyBuilder { HtmlBody = string.Format(template, logoPath, email, message.Content) };
                var logo = bodyBuilder.LinkedResources.Add(logoPath);
                logo.ContentId = MimeUtils.GenerateMessageId();
                bodyBuilder.HtmlBody = FormatTemplate(template, logo.ContentId, email, message.Content);
            }
            catch
            {
                //bodyBuilder = new BodyBuilder { HtmlBody = string.Format(DefaultTemplate, message.Content) };
                bodyBuilder = new BodyBuilder { HtmlBody = FormatTemplate(DefaultTemplate, message.Content) };
            }

            if (message.Attachments != null && message.Attachments.Any())
            {
                byte[] fileBytes;
                foreach (var attachment in message.Attachments)
                {
                    using (var ms = new MemoryStream())
                    {
                        attachment.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }

                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes,
                        ContentType.Parse(attachment.ContentType));
                }
            }

            mimeMessage.Body = bodyBuilder.ToMessageBody();
            list.Add(mimeMessage);
        }

        return list;
    }

    private async Task<List<MimeMessage>> SendResetPasswordAsync(EmailResetPasswordRequest resetPassword,
        CancellationToken token)
    {
        var list = new List<MimeMessage>();

        var (message, password) = await _repositories.GetId.GetNewPasswordAfterReset(resetPassword, token);

        if (message is null or "error" && password is null or "error")
            return await Task.FromResult(list);

        try
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(_emailConfig.From));

            mimeMessage.To.Add(new MailboxAddress(resetPassword.registeredEmail));

            mimeMessage.Subject = "Đã cung cấp mật khẩu mới";

            // Create the HTML content with CSS styling
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = @"
            <style>
            h1 {
                color: #2c3e50;
                font-size: 24px;
                font-weight: bold;
                margin-bottom: 20px;
            }
            p {
                color: #34495e;
                font-size: 16px;
                line-height: 1.5;
                margin-bottom: 30px;
            }
            </style>
            <h1>Đã thay đổi mật khẩu</h1>
            <p>Mật khẩu của bạn đã được tại mới thành công, hãy đăng nhập lại và thay đổi mật khẩu mới</p> 
            <br>" + $"<br><p>Đây là mật khẩu mới của bạn</p>  <br><p>{password}</p>"
            };

            // Set the content of the message
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            list.Add(mimeMessage);
        }
        catch
        {
            return await Task.FromResult(list);
        }

        return list;
    }

    private async Task<List<MimeMessage>> CreateListOfUnpaidInvoiceWithRenterName(int buildingId,
        List<Invoice> unpaidInvoices, CancellationToken token)
    {
        var list = new List<MimeMessage>();

        var employee = await _repositories.Buildings
            .GetBuildingDetail(buildingId).FirstOrDefaultAsync(token);

        if (employee == null)
            return await Task.FromResult(list);

        foreach (var invoice in unpaidInvoices)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(_emailConfig.From));

            mimeMessage.To.Add(new MailboxAddress(employee.Employee.Email));

            mimeMessage.Subject = "Nhắc hẹn về việc những khách hàng chưa thanh toán hóa đơn";

            var bodyBuilder = new BodyBuilder();

            var renter = new RenterEmailDetailEntity
            {
                Fullname = invoice.Renter.FullName,
                PhoneNumber = invoice.Renter.PhoneNumber,
                Email = invoice.Renter.Email,
                FlatName = invoice.Contract.Flat.Name,
                TotalAmount = invoice.TotalAmount
            };

            var tableBuilder = new StringBuilder();

            // Generate the HTML table dynamically based on the MyObject properties

            tableBuilder.Append("<table>");
            tableBuilder.Append("<tr>");

            foreach (var displayName in
                     from PropertyDescriptor prop
                         in TypeDescriptor.GetProperties(renter)
                     where prop.IsBrowsable
                     select prop.DisplayName)
                tableBuilder.Append($"<th>{displayName}</th>");

            tableBuilder.Append("</tr>");

            foreach (var prop in typeof(RenterEmailDetailEntity).GetFilteredProperties())
                tableBuilder.Append($"<td>{prop.GetValue(renter)}</td>");

            tableBuilder.Append("</tr>");
            tableBuilder.Append("</table>");

            // Another table for invoice detail

            // Get distinct nullable property values in a list of objects

            var footerBuilder = new StringBuilder();
            footerBuilder.Append("<h3>Thank you for your attention!</h3>");

            // Apply CSS styles to the HTML table
            const string bgColor = "#333";
            const string textColor = "#ffffff ";
            const string headerBgColor = "#444";
            const string headerTextColor = "#ffffff";

            bodyBuilder.HtmlBody =
                $"<head>" +
                $"<style>" +
                $"table {{ font-family: Arial, sans-serif; border-collapse: collapse; width: 100%; }} " +
                $"th, td {{ text-align: left; padding: 8px; }} " +
                $"th {{ background-color: {headerBgColor}; color: {headerTextColor}; }} " +
                $"td {{ background-color: {bgColor}; color: {textColor}; }} " +
                $"tr:nth-child(even) {{ background-color: #222; }}" +
                $"</style>" +
                $"</head>" +
                $"<body style='background-color: {bgColor}; color: {textColor};'>" +
                $"<h1 color: #ffffff>Xin chào, bạn hiện đang có 1 hoá đơn chờ thanh toán!</h1>" +
                $"<h3>Đây là hoá đơn cần thanh toán</h3>" +
                $"<br>" +
                $"<br>" +
                $"{tableBuilder}" +
                $"<br>" +
                $"<br>" +
                $"{footerBuilder}" +
                $"</body>";

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            list.Add(mimeMessage);
        }

        return await Task.FromResult(list);
    }

    private async Task<List<MimeMessage>> CreatePaymentReminderMimeMessage(List<Invoice> unpaidInvoices)
    {
        //List<String> receivers = unpaidInvoices.Select(e => e.Renter.Email).ToList();
        var list = new List<MimeMessage>();
        /*
        var templatePath = rootPath + Path.DirectorySeparatorChar + MailTemplateHelper.FOLDER +
                           Path.DirectorySeparatorChar + MailTemplateHelper.PAYMENT_REMINDER_TEMPLATE_FILE;
        var template = MailTemplateHelper.PAYMENT_REMINDER_TEMPLATE(rootPath);
        var logoPath = rootPath + Path.DirectorySeparatorChar + "Images" + Path.DirectorySeparatorChar +
                       "logowhite.png";
        */

        if (!unpaidInvoices.Any())
            return await Task.FromResult(list);

        foreach (var invoice in unpaidInvoices)
        {
            var mimeMessage = new MimeMessage();

            mimeMessage.From.Add(new MailboxAddress(_emailConfig.From));

            mimeMessage.To.Add(new MailboxAddress(invoice.Renter.Email));

            mimeMessage.Subject = "Nhắc hẹn về việc thanh toán hoá đơn";

            var bodyBuilder = new BodyBuilder();

            // Generate the HTML table dynamically based on the MyObject properties

            var invoiceMapped = _mapper.Map<InvoiceEmailDetailEntity>(invoice);

            var tableBuilder = new StringBuilder();

            tableBuilder.Append("<table>");
            tableBuilder.Append("<tr>");

            foreach (var displayName in
                     from PropertyDescriptor prop
                         in TypeDescriptor.GetProperties(invoiceMapped)
                     where prop.IsBrowsable
                     select prop.DisplayName)
                tableBuilder.Append($"<th>{displayName}</th>");

            tableBuilder.Append("</tr>");

            foreach (var prop in typeof(InvoiceEmailDetailEntity).GetFilteredProperties())
                tableBuilder.Append($"<td>{prop.GetValue(invoiceMapped)}</td>");

            tableBuilder.Append("</tr>");
            tableBuilder.Append("</table>");

            // Another table for invoice detail

            var tableBuilderDetail = new StringBuilder();

            // Generate the HTML table dynamically based on the MyObject properties

            tableBuilderDetail.Append("<table>");
            tableBuilderDetail.Append("<tr>");

            if (invoice.InvoiceDetails.Count != 0)
            {
                var properties = typeof(InvoiceDetailEmailEntity).GetProperties()
                    .Where(prop => Attribute.IsDefined(prop, typeof(DisplayNameAttribute)))
                    .Select(prop => new
                    {
                        prop.Name, prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName
                    });

                foreach (var property in properties) tableBuilderDetail.Append($"<th>{property.DisplayName}</th>");

                tableBuilderDetail.Append("<tr>");

                foreach (var invoiceDetail in invoice.InvoiceDetails)
                {
                    tableBuilderDetail.Append("<tr>");

                    var invoiceDetailObject = new InvoiceDetailEmailEntity
                    {
                        Name = invoiceDetail.Name,
                        Amount = invoiceDetail.Amount,
                        Price = invoiceDetail.Price
                    };

                    foreach (var prop in typeof(InvoiceDetailEmailEntity).GetFilteredProperties())
                        tableBuilderDetail.Append($"<td>{prop.GetValue(invoiceDetailObject)}</td>");

                    tableBuilderDetail.Append("</tr>");
                }

                tableBuilderDetail.Append("</tr>");
                tableBuilderDetail.Append("</table>");
            }

            // Get distinct nullable property values in a list of objects

            var footerBuilder = new StringBuilder();
            footerBuilder.Append("<h3>Thank you for your attention!</h3>");

            // Apply CSS styles to the HTML table
            const string bgColor = "#333";
            const string textColor = "#ffffff ";
            const string headerBgColor = "#444";
            const string headerTextColor = "#ffffff";

            bodyBuilder.HtmlBody =
                $"<head>" +
                $"<style>" +
                $"table {{ font-family: Arial, sans-serif; border-collapse: collapse; width: 100%; }} " +
                $"th, td {{ text-align: left; padding: 8px; }} " +
                $"th {{ background-color: {headerBgColor}; color: {headerTextColor}; }} " +
                $"td {{ background-color: {bgColor}; color: {textColor}; }} " +
                $"tr:nth-child(even) {{ background-color: #222; }}" +
                $"</style>" +
                $"</head>" +
                $"<body style='background-color: {bgColor}; color: {textColor};'>" +
                $"<h1 color: #ffffff>Xin chào, bạn hiện đang có 1 hoá đơn chờ thanh toán!</h1>" +
                $"<h3>Đây là hoá đơn cần thanh toán</h3>" +
                $"<br>" +
                $"<br>" +
                $"{tableBuilder}" +
                $"<br>" +
                $"<br>" +
                $"{tableBuilderDetail}" +
                $"<br>" +
                $"<br>" +
                $"{footerBuilder}" +
                $"</body>";

            /*
            try
            {
                var name = invoice.Renter.FullName;
                //<!--{0} is logo-->
                //<!--{1} is username-->
                //<!--{2} is content-->
                //bodyBuilder = new BodyBuilder { HtmlBody = string.Format(template, logoPath, email, message.Content) };
                var logo = bodyBuilder.LinkedResources.Add(logoPath);
                logo.ContentId = MimeUtils.GenerateMessageId();

                bodyBuilder.HtmlBody = FormatTemplate(template, logo.ContentId, name,
                    invoice.DueDate?.ToString("dd/MM/yy") ?? DateTime.Now.ToString("dd/MM/yyyy"),
                    invoice.ToHtmlTable());
            }
            catch
            {
                //bodyBuilder = new BodyBuilder { HtmlBody = string.Format(DefaultTemplate, message.Content) };
                bodyBuilder = new BodyBuilder
                {
                    HtmlBody = FormatTemplate(DefaultTemplate, invoice.ToHtmlTable())
                };
            }
            */
            //if (message.Attachments != null && message.Attachments.Any())
            //{
            //    byte[] fileBytes;
            //    foreach (var attachment in message.Attachments)
            //    {
            //        using (var ms = new MemoryStream())
            //        {
            //            attachment.CopyTo(ms);
            //            fileBytes = ms.ToArray();
            //        }

            //        bodyBuilder.Attachments.Add(attachment.FileName, fileBytes,
            //            ContentType.Parse(attachment.ContentType));
            //    }
            //}

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            list.Add(mimeMessage);
        }

        return await Task.FromResult(list);
    }


    /// <summary>
    ///     Replacing {number} marker in the email template with string values
    /// </summary>
    /// <param name="template">Email template</param>
    /// <param name="values">String values</param>
    /// <returns></returns>
    private static string FormatTemplate(string template, string logoContentId, params string[] values)
    {
        template = template.Replace("{logo}", logoContentId);
        for (var i = 0; i < values.Length; i++)
            // {{{i}}}: {0}, {1} in string
            template = template.Replace($"{{{i}}}", values[i]);
        return template;
    }


    private async Task SendAsync(MimeMessage mailMessage)
    {
        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.AppPassword);

            await client.SendAsync(mailMessage);
        }
        finally
        {
            await client.DisconnectAsync(true);
            client.Dispose();
        }
    }

    #region Unused Code

    //public bool SendSimpleMail(MailMessageEntity message)
    //{
    //    var emailMessage = CreateSimpleEmailMessage(message);

    //    Send(emailMessage);
    //    return true;
    //}
    //public bool SendSimpleMail(IEnumerable<string> receivers, string subject, string content, IFormFileCollection attachments)
    //{
    //    MailMessageEntity message = new MailMessageEntity(receivers, subject, content, attachments);
    //    var emailMessage = CreateSimpleEmailMessage(message);

    //    Send(emailMessage);
    //    return true;
    //}

    //public async Task<bool> SendSimpleEmailAsync(MailMessageEntity message)
    //{
    //    var mailMessage = CreateSimpleEmailMessage(message);

    //    await SendAsync(mailMessage);
    //    return true;
    //}

    //public async Task<bool> SendSimpleMailAsync(IEnumerable<string> receivers, string subject, string content, IFormFileCollection attachments)
    //{
    //    MailMessageEntity message = new MailMessageEntity(receivers, subject, content, attachments);
    //    var mailMessage = CreateSimpleEmailMessage(message);

    //    await SendAsync(mailMessage);
    //    return true;
    //}
    //private MimeMessage CreateEmailMessageWithSimpleTemplate(MailMessageEntity message, string rootPath)
    //{
    //    var mimeMessage = new MimeMessage();
    //    mimeMessage.From.Add(new MailboxAddress(_emailConfig.From));
    //    mimeMessage.To.AddRange(message.Receivers);
    //    mimeMessage.Subject = message.Subject;


    //    BodyBuilder bodyBuilder;
    //    try
    //    {
    //        string templatePath = rootPath + Path.DirectorySeparatorChar.ToString() + "MailTemplate" + Path.DirectorySeparatorChar.ToString() + MailTemplateEnum.DEFAULT;
    //        string template = GetTemplate(templatePath);
    //        string email = message.Receivers.First().Address;
    //        //< !--{ 0} is username-->
    //        //     < !--{ 1} is content-->
    //        bodyBuilder = new BodyBuilder { HtmlBody = string.Format(template, email, message.Content) };
    //    }
    //    catch
    //    {
    //        bodyBuilder = new BodyBuilder { HtmlBody = string.Format(DefaultTemplate, message.Content) };
    //    }

    //    if (message.Attachments != null && message.Attachments.Any())
    //    {
    //        byte[] fileBytes;
    //        foreach (var attachment in message.Attachments)
    //        {
    //            using (var ms = new MemoryStream())
    //            {
    //                attachment.CopyTo(ms);
    //                fileBytes = ms.ToArray();
    //            }

    //            bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
    //        }
    //    }

    //    mimeMessage.Body = bodyBuilder.ToMessageBody();
    //    return mimeMessage;
    //}

    //private MimeMessage CreateSimpleEmailMessage(MailMessageEntity message)
    //{
    //    var emailMessage = new MimeMessage();
    //    emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
    //    emailMessage.To.AddRange(message.Receivers);
    //    emailMessage.Subject = message.Subject;

    //    //var bodyBuilder = new BodyBuilder { HtmlBody = string.Format(DefaultTemplate, message.Content) };
    //    var bodyBuilder = new BodyBuilder { HtmlBody = FormatTemplate(DefaultTemplate, message.Content) };

    //    if (message.Attachments != null && message.Attachments.Any())
    //    {
    //        byte[] fileBytes;
    //        foreach (var attachment in message.Attachments)
    //        {
    //            using (var ms = new MemoryStream())
    //            {
    //                attachment.CopyTo(ms);
    //                fileBytes = ms.ToArray();
    //            }

    //            bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
    //        }
    //    }

    //    emailMessage.Body = bodyBuilder.ToMessageBody();
    //    return emailMessage;
    //}
    //private void Send(MimeMessage mailMessage)
    //{
    //    using (var client = new SmtpClient())
    //    {
    //        try
    //        {
    //            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
    //            client.AuthenticationMechanisms.Remove("XOAUTH2");
    //            client.Authenticate(_emailConfig.UserName, _emailConfig.AppPassword);

    //            client.Send(mailMessage);
    //        }
    //        finally
    //        {
    //            client.Disconnect(true);
    //            client.Dispose();
    //        }
    //    }
    //}
    //public async Task<bool> SendEmailWithDefaultTemplateAsync(MailMessageEntity message)
    //{
    //    var mimeMessages = CreateMimeMessageWithSimpleTemplateList(message/*, rootPath*/);

    //    foreach (var mimeMessage in mimeMessages) await SendAsync(mimeMessage);
    //    return true;
    //}

    #endregion
}