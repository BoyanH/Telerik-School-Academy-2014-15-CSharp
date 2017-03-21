using LibrarySystem.Data.Common.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        readonly IUowData db;

        public HomeController(IUowData db)
        {
            this.db = db;
        }

        public HomeController()
        {
            db = new UowData();
        }

        [HttpGet]
        public ActionResult Search()
        {
            List<string> bookTitles = this.db.Books.All().Select(b => b.Title).ToList();
            var authorsNames = db.Authors.All().Select(a => a.Name).ToList();

            foreach (var item in authorsNames)
            {
                bookTitles.Add(item);
            }

            return Json(bookTitles, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {

            var categories = this.db.Categories.All().ToList();
            return View(categories);
        }

        public ActionResult Details(int id)
        {
            var bookDetails = this.db.Books.GetById(id);
            return View(bookDetails);
        }

        public ActionResult SelectBooks(string searchTerm)
        {
            ViewBag.searchTerm = searchTerm;
            var books = this.db.Books.All().Where(b => b.Title.ToLower().Contains(searchTerm.ToLower()) || b.Authors.Any(a => a.Name.ToLower().Contains(searchTerm.ToLower())));
            return View(books);
        }
    }
}