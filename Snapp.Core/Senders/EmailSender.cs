using System.Net;
using System.Net.Mail;

namespace Snapp.Core.Senders
{
    public static class EmailSender
    {
        public static void Send(string to, string subject, string body)
        {
            var password = "";
            var myMail = "";
            var mail = new MailMessage();
            var smtpServer = new SmtpClient();

            mail.From = new MailAddress(myMail, "اسنپ");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml=true;
            smtpServer.Port = 0;
            smtpServer.Credentials = new NetworkCredential(myMail, password);
            smtpServer.EnableSsl = false;

            smtpServer.Send(mail);

        }
    }
}
