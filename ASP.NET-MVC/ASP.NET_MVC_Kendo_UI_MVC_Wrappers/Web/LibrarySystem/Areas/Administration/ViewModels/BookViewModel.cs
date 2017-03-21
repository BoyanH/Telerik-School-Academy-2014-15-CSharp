using LibrarySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Areas.Administration.ViewModels
{
    public class BookViewModel
    {
        public static Expression<Func<Book, BookViewModel>> FromBook
        {
            get
            {
                return b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Website = b.Website,
                    Description = b.Description,
                    Category = b.Category.Name
                };
            }
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}