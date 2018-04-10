using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;

namespace ComfLedGinco.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : Controller
    {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("SendNotification")]
        public async Task PostMessage()
        {
            var apiKey = _configuration.GetSection("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").Value;
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("a.immoune@data-innovation.com", "Example User 1");
            List<EmailAddress> tos = new List<EmailAddress>
          {
              new EmailAddress("r.hamidouche@data-innovation.com", "Example User 2"),
              new EmailAddress("test3@example.com", "Example User 3"),
              new EmailAddress("test4@example.com","Example User 4")
          };

            var subject = "Hello world email from Sendgrid ";
            var htmlContent = "<strong>Hello world with HTML content</strong>";
            var displayRecipients = false; // set this to true if you want recipients to see each others mail id 
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, "", htmlContent, false);
            var response = await client.SendEmailAsync(msg);
        }
    }
}