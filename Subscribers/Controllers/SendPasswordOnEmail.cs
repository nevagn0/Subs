using System;
using System.Net;
using System.Net.Mail;
namespace Subscribers.Controllers
{
    public class SendPasswordOnEmail
    {
        public void Sendpassword(string email, string subject, string body)
        {
            try
            {
                string smtpServer = "smt.gmail.com";
                int smtpPort = 587;
                string smptAdmin = "shindyapkin0129@gmail.com";
                string smtpPassword = "Misha1029!";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(smptAdmin);
                mail.Subject = subject;
                mail.Body = body;

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
