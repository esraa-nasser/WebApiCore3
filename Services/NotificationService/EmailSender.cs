using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICoreLatestVersion.Dtos.EmailDtos;
using APICoreLatestVersion.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace APICoreLatestVersion.Services.NotificationService
{
    public class EmailSender : IEmailSender
    {
        
        private readonly EmailModel _emailSettings;
        public EmailSender(IOptions<EmailModel> emailSetting)
        {
            _emailSettings = emailSetting.Value;
        }
        public async Task SendEmail(SendEmailDto sendEmail)
        {           
            var Email = _emailSettings.Email;
            MimeMessage message = PrepareMsg(sendEmail);
            message.From.Add(new MailboxAddress(Email));
            await PrepareClient(message);
        }
        private async Task PrepareClient(MimeMessage message)
        {
            var Host = _emailSettings.Host;
            var Email = _emailSettings.Email;
            var Password = _emailSettings.Password;
            int PortNo = _emailSettings.PortNo;
            using (var client = new SmtpClient())
            {
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls;
                client.Connect(Host, PortNo, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(Email, Password);
                await client.SendAsync(message);
                client.Disconnect(true);
                client.Dispose();
            }
        }
        private MimeMessage PrepareMsg(SendEmailDto sendEmail)
        {
            MimeMessage message = new MimeMessage();
            message.To.Add(new MailboxAddress(sendEmail.To));
            message.Subject = sendEmail.Subject;

            message.Body = new TextPart("plain")
            {
                Text = sendEmail.Body
            };
            return message;
        }
    }
}
