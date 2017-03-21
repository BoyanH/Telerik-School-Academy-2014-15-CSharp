using LibrarySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Areas.Administration.ViewModels
{
    public class AuthorViewModel
    {
        public static Expression<Func<Author, AuthorViewModel>> FromAuthor
        {
            get
            {
                return a => new AuthorViewModel
                {
                    Id = a.Id,
                    Name = a.Name,
                    Books = string.Join(", ", a.Books.Select(n => n.Title))
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Books { get; set; }
    }
}