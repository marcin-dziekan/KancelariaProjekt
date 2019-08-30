using Darek_kancelaria.Controllers;
using Darek_kancelaria.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            ApplicationDbContext context = new ApplicationDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            string pass = "temporaryPass";
            var checkUser = UserManager.FindByEmail("marcin_dziekan@wp.pl");
            if (checkUser == null)
            {
                var user = new ApplicationUser();
                user.UserName = "marcin_dziekan@wp.pl";
                user.Email = "marcin_dziekan@wp.pl";
                user.AddDate = DateTime.Now;
                var adminUser = UserManager.Create(user, pass);
                if (adminUser.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, "Admin");
                }
            }

        }
        protected void Session_Start()
        {
             Logging.SaveVisitor(Request.UserHostAddress);
        }
    }
}
