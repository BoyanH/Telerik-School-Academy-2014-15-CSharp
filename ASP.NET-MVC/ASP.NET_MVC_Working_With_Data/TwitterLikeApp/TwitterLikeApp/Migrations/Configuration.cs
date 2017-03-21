namespace TwitterLikeApp.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TwitterLikeApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TwitterLikeApp.Models.ApplicationDbContext>
    {

        private static PasswordHasher passwordHash = new PasswordHasher();
        private static List<string> adminRoles = new List<string>() { "Admin" };

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TwitterLikeApp.Models.ApplicationDbContext";
        }

        protected override void Seed(TwitterLikeApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "BoyanH"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser
                {
                    UserName = "BoyanH",
                    Email = "bhristov96@gmail.com",
                    PasswordHash = passwordHash.HashPassword("Notrealpass1.")
                };

                manager.Create(user);
                manager.AddToRole(user.Id, "Admin");
            }

        }
    }
}
