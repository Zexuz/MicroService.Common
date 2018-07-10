using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using MicroService.Common.Core.Services.impl;

namespace MicroService.Common.Core.Services.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(List<MailAddress> to, string body, string subject, List<MailAddress> cc = null, bool isBodyHtml = false);
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}