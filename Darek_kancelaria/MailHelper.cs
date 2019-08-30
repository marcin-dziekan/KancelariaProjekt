using Darek_kancelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Darek_kancelaria
{
    public static class MailHelper
    {
        private static SmtpClient _smtpClient;
        static MailHelper()
        {
            _smtpClient = new SmtpClient();
        }

        public static bool SendMessage(string mailCallback, string content, string fromWho)
        {
            using (var db = new ApplicationDbContext())
            {
                var mailClient = db.Contacts.FirstOrDefault();
                if (mailClient != null)
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("kancelariamessage@gmail.com", "Strona kancelarii", Encoding.UTF8);
                        mail.Subject = "Zapytanie od klienta " + fromWho;
                        mail.Body = content + "<br> Adres email Pana\\Pani <a href=mailTo:\"" + mailCallback + "\">" + fromWho + "</a>";
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;
                        mail.SubjectEncoding = Encoding.UTF8;
                        mail.To.Add(new MailAddress(mailClient.Email));
                        _smtpClient.Send(mail);
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public static bool SendMessage(string sendTo, string login, string pass, string clientName)
        {
            using (var db = new ApplicationDbContext())
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("kancelariamessage@gmail.com", "Portal Kancelarii Adwokackiej Dariusz Dziekan", Encoding.UTF8);
                    mail.Subject = "Witam Pana/Panią " + clientName + " w Kancelarii Adwokackiej Dariusz Dziekan";
                    mail.Body = "Dzień Dobry <br /> Poniżej znadziecie Państwo dane niezbędne do zalogowania w serwisie http://adwokat.dziekan.pl <br/> Login: " + login + "<br/> Hasło: " + pass + "<br/> Pozdrawiamy, <br/> Kancelaria Adwokacka Dariusz Dziekan";
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    mail.SubjectEncoding = Encoding.UTF8;
                    mail.To.Add(new MailAddress(sendTo));
                    _smtpClient.Send(mail);
                    return true;
                }

            }
        }
    }
}