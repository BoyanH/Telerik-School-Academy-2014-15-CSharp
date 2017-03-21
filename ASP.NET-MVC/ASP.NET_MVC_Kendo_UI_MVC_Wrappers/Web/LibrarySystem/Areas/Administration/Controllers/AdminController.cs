using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LibrarySystem.Data.Common.Repositories;
using LibrarySystem.Data.Models;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using LibrarySystem.Areas.Administration.ViewModels;

namespace LibrarySystem.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        readonly IUowData db;

        public AdminController(IUowData db)
        {
            this.db = db;
        }

        public AdminController()
        {
            db = new UowData();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return this.PartialView("_Categories");
        }

        public ActionResult Books()
        {
            return this.PartialView("_Books");
        }

        public JsonResult CreateBooks([DataSourceRequest]
                                      DataSourceRequest request, BookViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var newBook = new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    ISBN = book.ISBN,
                    Website = book.Website,
                    Description = book.Description,
                    Category = new Category { Name = book.Category }
                };

                this.db.Books.Add(newBook);
                this.db.SaveChanges();

                book.Id = newBook.Id;
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadBooks([DataSourceRequest]
                                    DataSourceRequest request)
        {
            var books = this.db.Books.All().Select(BookViewModel.FromBook);
            return Json(books.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBooks([DataSourceRequest]
                                      DataSourceRequest request, BookViewModel book)
        {
            var existingBook = this.db.Books.All().FirstOrDefault(b => b.Id == book.Id);

            if (book != null && ModelState.IsValid)
            {
                existingBook.Id = book.Id;
                existingBook.Title = book.Title;
                existingBook.ISBN = book.ISBN;
                existingBook.Website = book.Website;
                existingBook.Description = book.Description;
                existingBook.Category = new Category { Name = book.Category };

                this.db.SaveChanges();
            }

            return Json((new[] { book }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBooks([DataSourceRequest]
                                      DataSourceRequest request, BookViewModel book)
        {
            var existingBook = this.db.Books.All().FirstOrDefault(b => b.Id == book.Id);

            this.db.Books.Delete(existingBook);
            this.db.SaveChanges();

            return Json(new[] { book }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CreateCategory([DataSourceRequest]
                                         DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };

                this.db.Categories.Add(newCategory);
                this.db.SaveChanges();

                category.Id = newCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadCategories([DataSourceRequest]
                                         DataSourceRequest request)
        {
            var categories = this.db.Categories.All().Select(CategoryViewModel.FromCategory);
            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateCategories([DataSourceRequest]
                                           DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.db.Categories.All().FirstOrDefault(c => c.Id == category.Id);

            if (category != null && ModelState.IsValid)
            {
                existingCategory.Id = category.Id;
                existingCategory.Name = category.Name;

                this.db.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCategories([DataSourceRequest]
                                           DataSourceRequest request, CategoryViewModel category)
        {
            var existingCategory = this.db.Categories.All().FirstOrDefault(c => c.Id == category.Id);

            this.db.Categories.Delete(existingCategory);
            this.db.SaveChanges();

            return Json(new[] { category }, JsonRequestBehavior.AllowGet);
        }
    }
}