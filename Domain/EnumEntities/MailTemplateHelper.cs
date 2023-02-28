﻿using System.Text;
using Domain.EntitiesForManagement;

namespace Domain.EnumEntities;

public static class MailTemplateHelper
{
    public static string FOLDER = "MailTemplates";

    public static readonly string DEFAULT_TEMPLATE_FILE = "MailTemplate.html";
    public static readonly string PAYMENT_REMINDER_TEMPLATE_FILE = "PaymentReminderTemplate.html";
    public static readonly string PAYMENT_CONFIRM_TEMPLATE_FILE = "PaymentConfirmTemplate.html";

    public static string DEFAULT_TEMPLATE(string rootPath)
    {
        if (string.IsNullOrEmpty(default_template))
            default_template = GetTemplate(rootPath + Path.DirectorySeparatorChar + FOLDER +
                                           Path.DirectorySeparatorChar + DEFAULT_TEMPLATE_FILE);
        return default_template;
    }

    public static string PAYMENT_REMINDER_TEMPLATE(string rootPath)
    {
        if (string.IsNullOrEmpty(payment_reminder_template))
            default_template = GetTemplate(rootPath + Path.DirectorySeparatorChar + FOLDER +
                                           Path.DirectorySeparatorChar + PAYMENT_REMINDER_TEMPLATE_FILE);
        return payment_confirm_template;
    }

    public static string PAYMENT_CONFIRM_TEMPLATE(string rootPath)
    {
        if (string.IsNullOrEmpty(default_template))
            default_template = GetTemplate(rootPath + Path.DirectorySeparatorChar + FOLDER +
                                           Path.DirectorySeparatorChar + PAYMENT_CONFIRM_TEMPLATE_FILE);
        return payment_confirm_template;
    }

    public static string GetTemplate(string templatePath)
    {
        string template;
        try
        {
            using (var streamReader = File.OpenText(templatePath))
            {
                template = streamReader.ReadToEnd();
            }
        }
        catch
        {
            Console.WriteLine($"Get Email Template {templatePath}: Not found");
            return DEFAULT_TEMPLATE_FILE;
        }

        return template;
    }

    public static string ToHtmlTable(this Invoice invoice)
    {
        var tables = "";
        var serviceTable = new StringBuilder("");
        serviceTable.Append("<table class=\"service-table\">");
        serviceTable.Append("<thead>");
        serviceTable.Append("<th>Service</th>");
        serviceTable.Append("<th>Price</th>");
        serviceTable.Append("<th>Quantity</th>");
        serviceTable.Append("<th>Fee</th>");
        serviceTable.Append("</thead>");
        serviceTable.Append("<tbody>");

        var requesttable = new StringBuilder("");
        requesttable.Append("<table class=\"service-table\">");
        requesttable.Append("<thead>");
        requesttable.Append("<th>Ticket</th>");
        requesttable.Append("<th>Price</th>");
        requesttable.Append("<th>Quantity</th>");
        requesttable.Append("<th>Fee</th>");
        requesttable.Append("</thead>");
        requesttable.Append("<tbody>");

        decimal serviceTotal = 0;
        decimal requestTotal = 0;
        var hasService = false;
        var hasRequest = false;
        foreach (var detail in invoice.InvoiceDetails)
        {
            if (detail.Service != null)
            {
                serviceTable.Append("<tr>");
                serviceTable.Append($"<td>{detail.Service.Name}</td >");
                serviceTable.Append($"<td>{detail.Amount}</td >");
                serviceTable.Append($"<td>{detail.Amount * detail.Service.Amount}</td>");

                serviceTable.Append("</tr>");
                serviceTotal += detail.Amount * detail.Amount;
                hasService = true;
            }

            /*
            if (detail.Ticket != null)
            {
                requesttable.Append("<tr>");
                requesttable.Append($"<td>{detail.Ticket.TicketName}</td >");
                requesttable.Append($"<td>{detail.Amount}</td >");
                requesttable.Append($"<td>{detail.Amount * detail.Ticket.Amount}</td>");

                requesttable.Append("</tr>");
                requestTotal += detail.Amount * detail.Ticket.Amount;
                hasRequest = true;
            }
            */
        }

        if (hasService)
        {
            serviceTable.Append("<tr>");
            serviceTable.Append("<td colspan=\"3\">Total</td >");
            serviceTable.Append($"<td>{serviceTotal}</td >");
            serviceTable.Append("</tr>");
            serviceTable.Append("</tbody>");
            serviceTable.Append("</table>");
            tables += serviceTable.ToString();
        }

        if (hasRequest)
        {
            requesttable.Append("<tr>");
            requesttable.Append("<td colspan=\"3\">Total</td >");
            requesttable.Append($"<td>{requestTotal}</td >");
            requesttable.Append("</tr>");
            requesttable.Append("</tbody>");
            requesttable.Append("</table>");
            tables += requesttable.ToString();
        }

        return tables;
    }

    #region field

    public static string default_template;
    public static string payment_reminder_template;
    private static string payment_confirm_template;

    #endregion
}