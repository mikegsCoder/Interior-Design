using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;

namespace InteriorDesign.Core.Services.Common.EmailSendService
{
    public class AppEmailSender : IAppEmailSender
    {
        private readonly IConfiguration _configuration;

        public AppEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Sends emails from mikegsid@gmail.com
        public async Task SendAsync(string subject, string body, string emailTo)
        {
            var message = new MailMessage();

            message.To.Add(new MailAddress(emailTo));
            message.From = new MailAddress(_configuration["Smtp:Email"]);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "apikey",
                    Password = _configuration["SendGridKey"]
                };

                client.Credentials = credential;
                client.Host = _configuration["Smtp:Host"];
                client.Port = int.Parse(_configuration["Smtp:Port"]);
                client.EnableSsl = false;

                await client.SendMailAsync(message);
            }
        }
    }
}
