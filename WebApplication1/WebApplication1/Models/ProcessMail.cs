using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Threading;

namespace MailClassLibrary

{
    public static class ProcessMail
    {

        public static void SendMail(string emailid, string subject, string body)
        {
            //throw new System.Exception("Throw Exception");
            Task t = Task.Run(() =>
            {
                SendEmailInAThread(emailid, subject, body);
            });
        }

        public static bool SendEmailInAThread(string emailid, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.EnableSsl = true; 
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("canto@lucadangelo.it", "De7t!belli");

            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("canto@lucadangelo.it");

            msg.To.Add(new MailAddress(emailid));
            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.Body = body;
            client.Send(msg);

            return true; 
        }


    }
}