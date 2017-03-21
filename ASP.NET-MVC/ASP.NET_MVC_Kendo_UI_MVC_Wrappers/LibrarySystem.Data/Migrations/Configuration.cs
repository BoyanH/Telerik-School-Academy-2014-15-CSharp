namespace LibrarySystem.Data.Migrations
{
    using LibrarySystem.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibrarySystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(LibrarySystemDbContext context)
        {
            if (context.Categories.Any() || context.Books.Any() || context.Authors.Any())
            {
                return;
            };
            this.AddCategories(context);
            this.AddUsers(context);
            this.AddAdmin(context);
        }

        private void AddUsers(LibrarySystemDbContext context)
        {
            var hasher = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.Id,
                new ApplicationUser
                {
                    UserName = "Pesho@abv.bg",
                    PasswordHash = hasher.HashPassword("123456"),
                    Email = "Pesho@abv.bg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new ApplicationUser
                {
                    UserName = "Gosho@abv.bg",
                    PasswordHash = hasher.HashPassword("123456"),
                    Email = "Gosho@abv.bg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new ApplicationUser
                {
                    UserName = "Mimi@abv.bg",
                    PasswordHash = hasher.HashPassword("123456"),
                    Email = "Mimi@abv.bg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new ApplicationUser
                {
                    UserName = "Ivan@abv.bg",
                    PasswordHash = hasher.HashPassword("123456"),
                    Email = "Ivan@abv.bg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                },
                new ApplicationUser
                {
                    UserName = "Stoqn@abv.bg",
                    PasswordHash = hasher.HashPassword("123456"),
                    Email = "Stoqn@abv.bg",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = true
                });
        }


        private void AddCategories(LibrarySystemDbContext context)
        {
            context.Categories.AddOrUpdate(c => c.Id,
                new Category
                {
                    Name = "Web Development",
                    Books = new List<Book>()
                    {
                        new Book{Title = "CSS: The Missing Manual", 
                            Description = "Want to learn how to turn humdrum Web sites into destinations that will capture viewers and keep them longer? Pick up CSS: The Missing Manual and learn the real magic of this tool.", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "David Sawyer McFarland"}
                        },
                        ISBN = "0-14-020652-3",
                        Website = ""},
                        new Book{Title = "CSS: The Definitive Guide", 
                            Description = "CSS: The Definitive Guide, 3rd Edition, provides you with a comprehensive guide to CSS implementation, along with a thorough review of all aspects of CSS 2.1.", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Eric A. Meyer"}
                        },
                        ISBN = "6-54-024232-1",
                        Website = ""},
                        new Book{Title = "Simply JavaScript", 
                            Description = "Everything you need to learn JavaScript from Scratch!", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Kevin Yank"}
                        },
                        ISBN = "6-54-023452-1",
                        Website = ""},
                        new Book{Title = "Agile Web Development with Rails, 2nd Edition", 
                            Description = "The definitive, Jolt-award winning guide to learning and using Rails is now in its Second Edition.", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Dave Thomas"}
                        },
                        ISBN = "",
                        Website = ""},}
                },
                new Category
                {
                    Name = "Algorithms",
                    Books = new List<Book>()
                    {
                        new Book{Title = "Introduction to Algorithms, 3rd Edition", 
                            Description = "Introduction to Algorithms uniquely combines rigor and comprehensiveness. The book covers a broad range of algorithms in depth, yet makes their design and analysis accessible to all levels of readers. ", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Thomas H. Cormen"}
                        },
                        ISBN = "",
                        Website = ""},
                        new Book{Title = "Elements of Programming Interviews: The Insiders' Guide", 
                            Description = "Solutions include code snippets which are primarily in C++. Programs concerned with concurrency are in Java. Complete programs are available at epibook.github.io. Java versions of the C++ programs in the book can be found at the website.", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Adnan Aziz"}
                        },
                        ISBN = "1-03-041215-0",
                        Website = ""},
                        new Book{Title = "Algorithms (4th Edition)", 
                            Description = "This book surveys the most important computer algorithms currently in use and provides a full treatment of data structures and algorithms for sorting, searching, graph processing, and string processing -- including fifty algorithms every programmer should know.", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Robert Sedgewick"},
                            new Author{Name = "Kevin Wayne"}
                        },
                        ISBN = "6-54-023452-1",
                        Website = ""},}
                },
                new Category
                {
                    Name = "Rocket Science",
                },
                new Category
                {
                    Name = "System Administration",
                    Books = new List<Book>()
                    {
                        new Book{Title = "The Practice of System and Network Administration (Paperback) ", 
                            Description = "The first edition of \"The Practice of System and Network Administration\" introduced a generation of system and network administrators to a modern IT methodology. ", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Thomas A. Limoncelli"},
                            new Author {Name = "Evi Nemeth"},
                            new Author {Name = "Ben Laurie"}
                        },
                        ISBN = "",
                        Website = ""},
                        new Book{Title = "Pro Puppet", 
                            Description = "Pro Puppet, Second Edition, now updated for Puppet 3, is an in-depth guide to installing, using, and developing the popular configuration management tool Puppet", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Jeffrey McCune"},
                            new Author{Name = "James Turnbull"},
                            new Author {Name = "Spencer Krum"},
                            new Author{Name = "William Van Hevelingen"}
                        },
                        ISBN = "",
                        Website = ""},
                        new Book{Title = "Debian GNU/Linux 2.1 Unleashed", 
                            Description = "This book covers the most important topics to the Debian Linux intermediate/advanced user on installation and management of Debian systems.", 
                            Authors = new List<Author>()
                        {
                            new Author {Name = "Mario Camou"},
                            new Author{Name = "John Goerzen"},
                            new Author{Name = "Aaron Van Couwenberghe"}
                        },
                        ISBN = "6-54-0234232-1",
                        Website = ""}}
                });
        }

        private void AddAdmin(LibrarySystemDbContext context)
        {
            const string RoleName = "Admin";

            var userRole = new IdentityRole { Name = RoleName, Id = Guid.NewGuid().ToString() };
            context.Roles.AddOrUpdate(userRole);

            var hasher = new PasswordHasher();

            var user = new ApplicationUser
            {
                UserName = "Admin@abv.bg",
                PasswordHash = hasher.HashPassword("123456"),
                Email = "Admin@abv.bg",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true
            };

            user.Roles.Add(new IdentityUserRole { RoleId = userRole.Id, UserId = user.Id });
            context.Users.AddOrUpdate(user);
        }

    }
}
