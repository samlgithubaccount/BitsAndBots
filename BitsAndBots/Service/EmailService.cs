using System.Net;
using System.Net.Mail;

namespace BitsAndBots.Service
{
    public class EmailService
    {
        private SmtpClient Client;
        private string fromAddress;

        public EmailService()
        {
            //TODO: Fetch details from appsettings and turn this into an actual service
            var server = "smtp.gmail.com";
            var port = 587;
            fromAddress = "<add gmail address here>";
            var password = "<add google app password here>";
            var credentials = new NetworkCredential(fromAddress, password);
            var useSsl = true;

            Client = new SmtpClient(server)
            {
                Port = port,
                Credentials = credentials,
                EnableSsl = useSsl,
            };
        }

        public void SendEmail(string toAddress, string subject, string body)
        {
            MailMessage message = new MailMessage(
                fromAddress,
                toAddress,
                subject,
                body);

            Client.Send(message);
        }
    }
}
