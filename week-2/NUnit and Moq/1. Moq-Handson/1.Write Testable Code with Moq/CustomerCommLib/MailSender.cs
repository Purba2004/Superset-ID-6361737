using System;
using System.Net;
using System.Net.Mail;

namespace CustomerCommLib
{
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                
                mail.From = new MailAddress("your.email.27.06.25@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = "Test Mail";
                mail.Body = message;

                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(
                    "your.email.27.06.25@gmail.com",
                    "nkbu kctq afee tnzj" 
                );
                smtpServer.EnableSsl = true;

                smtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
    }
}
