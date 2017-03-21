using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesApp.Data;
using MoviesApp.Models;

namespace MoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        private MovieContext db = new MovieContext();

        // GET: Movies
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Details", movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.maleList = new SelectList(db.Actors.Where(m => m.IsMale == true), "ActorId", "Name");
            ViewBag.femaleList = new SelectList(db.Actors.Where(m => m.IsMale == false), "ActorId", "Name");
            return PartialView("_Create");
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MovieId,Title,Director,Year,Studio,StudioAddress,LeadingMaleRoleId,LeadingFemaleRoleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                var maleActor = db.Actors.FirstOrDefault(m => m.ActorId == movie.LeadingMaleRoleId);
                var femaleActor = db.Actors.FirstOrDefault(m => m.ActorId == movie.LeadingFemaleRoleId);
                movie.LeadingMaleRole = maleActor;
                movie.LeadingFemaleRole = femaleActor;
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("_Create", movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Edit", movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MovieId,Title,Director,Year,Studio,StudioAddress,LeadingMaleRoleId,LeadingFemaleRoleId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("_Edit", movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Delete", movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
