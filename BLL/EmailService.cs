using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EmailService
    {
        public void SendEmail(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)
        {
            string from = yourGmailUserName; // From address    
            MailMessage message = new MailMessage(from, toEmail)
            {
                Subject = subject,
                Body = body,
                BodyEncoding = Encoding.UTF8,
                IsBodyHtml = true
            };

            using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)) // Gmail SMTP
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false; // Set to false since you are providing credentials
                client.Credentials = new System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);

                try
                {
                    client.Send(message);
                }
                catch (Exception)
                {
                    throw; // Preserve stack trace
                }
            }
        }
        public void SendEmail2(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)

        {
            string to = toEmail; //To address    
            string from = yourGmailUserName; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
