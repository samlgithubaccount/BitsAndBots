using BitsAndBots.Configuration;
using System.Net;
using System.Net.Mail;

namespace BitsAndBots.Service
{
    public class EmailService
    {
        private SmtpClient Client;
        private EmailCredential EmailCredential;

        public EmailService(EmailCredential emailCredential)
        {
            EmailCredential = emailCredential;
            var credentials = new NetworkCredential(emailCredential.Address, emailCredential.Password);

            Client = new SmtpClient(emailCredential.Server)
            {
                Port = emailCredential.Port,
                Credentials = credentials,
                EnableSsl = emailCredential.UseSsl
            };
        }

        public void SendEmail(string toAddress, string subject, string body)
        {
            MailMessage message = new MailMessage(
                EmailCredential.Address,
                toAddress,
                subject,
                body);

            Client.Send(message);
        }
    }
}
