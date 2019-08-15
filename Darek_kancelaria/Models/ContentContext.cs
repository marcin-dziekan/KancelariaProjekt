using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Darek_kancelaria.Models
{
    public class ContentContext : DbContext
    {
        public ContentContext() : base("LawBaseSec")
        {
            Database.SetInitializer<ContentContext>(new DropCreateDatabaseIfModelChanges<ContentContext>());
        }

        public DbSet<FaceCountModel> Faces { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<PageContent> PageContents {get; set;}
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<BlogModel> Blogs { get; set; }
    }
}