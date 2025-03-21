using System;
using System.Net;
using System.Net.Mail;
namespace Subscribers.Controllers
{
    public class SendPasswordOnEmail
    {
        public void SendPassword(string email, string subject, string body)
        {
            try
            {
                string smtpServer = "smtp.gmail.com";
                int smtpPort = 587;
                string smptAdmin = "shindyapkin0129@gmail.com";
                string smtpPassword = "lngv lpzv pglv ssuh";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smptAdmin);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;

                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
                smtpClient.Credentials = new NetworkCredential(smptAdmin, smtpPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                Console.WriteLine("Отправил");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка" + ex.Message);
            }
        }
    }
}
