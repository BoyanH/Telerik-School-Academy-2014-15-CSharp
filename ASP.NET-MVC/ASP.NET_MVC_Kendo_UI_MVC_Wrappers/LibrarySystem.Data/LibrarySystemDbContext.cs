using LibrarySystem.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarySystem.Data.Migrations;

namespace LibrarySystem.Data
{
    public class LibrarySystemDbContext : IdentityDbContext<ApplicationUser>
    {
        public LibrarySystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LibrarySystemDbContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public static LibrarySystemDbContext Create()
        {
            return new LibrarySystemDbContext();
        }
    }
}
