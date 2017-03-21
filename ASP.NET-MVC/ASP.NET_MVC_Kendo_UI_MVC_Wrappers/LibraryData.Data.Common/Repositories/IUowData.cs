using LibrarySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Data.Common.Repositories
{
    public interface IUowData : IDisposable
    {
        IRepository<Category> Categories { get; }

        IRepository<Book> Books { get; }

        IRepository<Author> Authors { get; }

        IRepository<ApplicationUser> Users { get; }

        int SaveChanges();
    }
}