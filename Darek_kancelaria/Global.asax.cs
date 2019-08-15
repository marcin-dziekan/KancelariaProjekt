using Darek_kancelaria.Controllers;
using Darek_kancelaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Darek_kancelaria
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // WAŻNE !!!!
            //Żeby utwożyć nowe konto w kontrolerze Account zmienić filtr na AllowAnonmous. Kod poniżej nie działa, żeby utworzyć nowego użytkownika trzeba byćzalogowanycm stąd ten błąd!!!

            //using(var db = new ApplicationDbContext())
            //{
            //    if(!db.Users.Where(x => x.Email == "dariusz_dziekan@wp.pl").Any())
            //    {
            //        var regModel = new RegisterViewModel
            //        {
            //            Email = "dariusz_dziekan@wp.pl",
            //            Password = "Maximus,.1",
            //            ConfirmPassword = "Maximus,.1"
            //        };
            //        var registered = new AccountController().Register(regModel);
            //    }
            //}
            //using(var cc = new ContentContext())
            //{
            //    if (!cc.Faces.Any())
            //    {
            //        cc.Faces.Add(new FaceCountModel());
            //        cc.SaveChanges();
            //    }
            //}
        }
        protected void Session_Start()
        {
             Logging.SaveVisitor(Request.UserHostAddress);
        }
    }
}
