using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICoreLatestVersion.Dtos.EmailDtos;
using APICoreLatestVersion.Services.NotificationService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace APICoreLatestVersion.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IEmailSender _emailServices;
        public NotificationController(IEmailSender emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpPost]
        [Route("SendEmail")]
        public async Task SendEmail(SendEmailDto sendEmailDto)
        {
            await _emailServices.SendEmail(sendEmailDto);
        }
    }
}