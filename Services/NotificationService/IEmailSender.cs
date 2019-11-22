using APICoreLatestVersion.Dtos.EmailDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Services.NotificationService
{
    public interface IEmailSender
    {
        Task SendEmail(SendEmailDto sendEmail);
    }
}
