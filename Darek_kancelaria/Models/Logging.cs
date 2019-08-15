using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public static class Logging
    {
        private static ContentContext _db;
        static Logging()
        {
            _db = new ContentContext();
        }

        public static void SaveVisitor(string ip)
        {
            var log = new Log
            {
                DateTime = DateTime.Now,
                IpAddress = ip,
                SMail = false
            };
            _db.Logs.Add(log);
            _db.SaveChanges();
        }


        /// <summary>
        /// Check if client send more than 3 messages per 12 hours if yes block client.
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string CheckSender(string ip, EmailModel model)
        {
            using (_db)
            {
                var getUser = _db.Logs.Where(x => x.IpAddress == ip && x.SMail == true).Where(x => x.DateTime.Year == DateTime.Now.Year && x.DateTime.Month == DateTime.Now.Month && x.DateTime.Day == DateTime.Now.Day && (x.DateTime.Hour - DateTime.Now.Hour) < 12).Count();
                if (getUser != 0 && getUser > 3)
                {
                    return "Możliwość wysyłania maili została dla Ciebie ZABLOKOWANA!!!";
                }
                else
                {
                    var log = new Log {
                        DateTime = DateTime.Now,
                        IpAddress = ip,
                        SMail = true,
                        EmailAddress = model.Email
                    };
                    if(MailHelper.SendMessage(model.Email, model.Question, model.Name))
                    {
                        _db.Logs.Add(log);
                        _db.SaveChanges();
                        return "Widomość została wysłana.";
                    }
                    else
                    {
                        return "Błąd. Właściciel serwisu nie wprowadził swojego adresu email.";
                    }

                }
            }
        }
    }
}