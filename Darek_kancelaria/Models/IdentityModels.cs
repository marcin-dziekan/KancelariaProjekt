using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Darek_kancelaria.Models
{
    // Możesz dodać dane profilu dla użytkownika, dodając więcej właściwości do klasy ApplicationUser. Odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=317594, aby dowiedzieć się więcej.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string FName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public DateTime AddDate { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Element authenticationType musi pasować do elementu zdefiniowanego w elemencie CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Dodaj tutaj niestandardowe oświadczenia użytkownika
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DaneKancelarii", throwIfV1Schema: false)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        public DbSet<FaceCountModel> Faces { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<PageContent> PageContents { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
        public DbSet<CaseModel> Cases { get; set; }
        public DbSet<DocumentModel> Documents { get; set; }
        public DbSet<Termcs> Terms { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}