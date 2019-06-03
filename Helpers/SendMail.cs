using ApplicationsFromCitizens.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Helpers
{
    public class SendMail
    {
        private readonly SmtpSettings _smtpSettings;

        public SendMail(IOptions<SmtpSettings> options)
        {
            _smtpSettings = options.Value;
        }

        /// <summary>
        /// Рассылка объявлений и новостей
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="bodyMail"></param>
        /// <param name="email"></param>
        /// <param name="replyTo"></param>
        public void SendCustom(string subject, string bodyMail, string email, string replyTo)
        {
            MailMessage mail = new MailMessage();
            SmtpClient client = new SmtpClient
            {
                Host = _smtpSettings.Host,
                EnableSsl = _smtpSettings.EnableSsl,
                Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                Port = _smtpSettings.Port
            };

            // Отправляем письмо различной тематикой
            mail.From = new MailAddress("noreply@mp-ges.ru");
            mail.To.Add(email);
            mail.ReplyToList.Add(replyTo);
            MailAddress hcc = new MailAddress("asu@mp-ges.ru");
            mail.Bcc.Add(hcc);
            mail.Subject = subject;
            mail.Body = bodyMail;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            client.Send(mail);
        }

        public static void SendPaytNew()
        {

        }
        
        public static void SendPasswordRecoveryUser(string email, string passw)
        {
            MailMessage Mail = new MailMessage();
            SmtpClient Client = new SmtpClient { EnableSsl = true };

            Mail.From = new MailAddress("noreply@mp-ges.ru");
            Mail.To.Clear();
            Mail.To.Add(email);
            Mail.Subject = "Напоминание пароля";
            Mail.Body = "Ваш пароль для доступа в личный кабинет http://kabinet.hm-ges.ru: " + passw;
            Mail.Priority = MailPriority.High;

            Client.Send(Mail);
        }

        /// <summary>
        /// Confirm Email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="url"></param>
        public static void SendConfirmEmail(string email, string url)
        {
            MailMessage Mail = new MailMessage();
            SmtpClient Client = new SmtpClient { EnableSsl = true };

            Mail.From = new MailAddress("noreply@mp-ges.ru");
            Mail.To.Add(email);
            Mail.Subject = "Подтверждение e-mail";
            Mail.Body = "Для завершения регистрации перейдите по ссылке:" +
                        $"<a href=\"{url}\" title=\"Подтвердить регистрацию\">Подтвердить</a>";
            Mail.IsBodyHtml = true;
            Mail.Priority = MailPriority.High;

            Client.Send(Mail);
        }
    }
}