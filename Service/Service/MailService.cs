using System.ComponentModel;
using System.Text;
using Application.IRepository;
using AutoMapper;
using Domain.CustomEntities.Mail;
using Domain.CustomEntities.MomoEntities;
using Domain.EntitiesForManagement;
using Domain.EnumEntities;
using Domain.ViewModel.InvoiceEntity;
using Domain.ViewModel.RenterEntity;
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

        return true;
    }

    public async Task<bool> SendListOfUnPaidRenterToSupervisor(int buildingId, CancellationToken token)
    {
        var unpaidInvoices =
            await _repositories.Invoices.GetUnpaidInvoice(buildingId, token);

        if (!unpaidInvoices.Any())
            return false;

        var mimeMessagesForAdmin =
            await CreateListOfUnpaidInvoiceWithRenterName(buildingId, unpaidInvoices, token);

        if (mimeMessagesForAdmin.Count == 0)
            return false;
        foreach (var mimeMessage in mimeMessagesForAdmin)
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

            mimeMessage.To.Add(new MailboxAddress("teenlonglanh@gmail.com"));

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

            mimeMessage.Subject = "Nhắc hẹn về việc thanh toán hoá đơnr";

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
                switch (prop.GetValue(invoiceMapped.ToString()?.ToLower()))
                {
                    case "unpaid":
                        tableBuilder.Append($"<td>{"Chưa thanh toán"}</td>");
                        break;
                    case "paid":
                        tableBuilder.Append($"<td>{"Đã thanh toán"}</td>");
                        break;
                    case "overdue":
                        tableBuilder.Append($"<td>{"Quá hạn"}</td>");
                        break;
                    case "paidoverdue":
                        tableBuilder.Append($"<td>{"Đã thanh toán quá hạn"}</td>");
                        break;
                    default:
                        tableBuilder.Append($"<td>{prop.GetValue(invoiceMapped)}</td>");
                        break;
                }

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