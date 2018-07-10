using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MicroService.Common.Core.Services.Interfaces;
using MicroService.Common.Core.ValueTypes.Types;

namespace MicroService.Common.Core.Services.impl
{
    public class GmailSenderService : IEmailSenderService
    {
        private readonly GmailSettings _gmailSettings;

        public GmailSenderService(GmailSettings gmailSettings)
        {
            _gmailSettings = gmailSettings;
        }

        public async Task SendEmailAsync(List<MailAddress> to, string body, string subject, List<MailAddress> cc = null,
                                         bool isBodyHtml = false)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_gmailSettings.Username, _gmailSettings.AppPassword),
                EnableSsl = true
            };

            var mail = new MailMessage
            {
                IsBodyHtml = isBodyHtml,
                Body = body,
                Subject = subject,
                From = new MailAddress("example@example.com")
            };

            //this does not matter!
            AddRange(to, mail.To.Add);

            if (cc != null)
                AddRange(cc, mail.CC.Add);
            await smtpClient.SendMailAsync(mail);
        }

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {
            var to = new List<MailAddress> {new MailAddress(emailRequest.Email.Value)};
            await SendEmailAsync(to, emailRequest.Body, emailRequest.Subject, isBodyHtml: emailRequest.IsHtml);
        }

        private static void AddRange(IEnumerable<MailAddress> list, Action<MailAddress> action)
        {
            foreach (var item in list)
            {
                action(item);
            }
        }
    }

    public class EmailRequest
    {
        public Email  Email   { get; }
        public string Body    { get; }
        public string Subject { get; }
        public bool   IsHtml  { get; }

        public EmailRequest(Email email, string body, string subject, bool isHtml)
        {
            Email = email;
            Body = body;
            Subject = subject;
            IsHtml = isHtml;
        }
    }

    public class GmailSettings
    {
        public string AppPassword { get; }
        public string Username    { get; }

        public GmailSettings(string appPassword, string username)
        {
            AppPassword = appPassword;
            Username = username;
        }
    }
}