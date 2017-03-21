using LibrarySystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LibrarySystem.Areas.Administration.ViewModels
{
    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return ca => new CategoryViewModel
                {
                    Id = ca.Id,
                    Name = ca.Name
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}