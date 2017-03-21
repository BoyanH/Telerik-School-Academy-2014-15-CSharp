namespace TwitterLikeApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using TwitterLikeApp.Models;
    using Microsoft.AspNet.Identity;

    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private void filterPostHashtags(Post post)
        {
            var regex = new Regex(@"(?<=#)\w+");
            var matches = regex.Matches(post.Content)
                .OfType<Match>()
                .Distinct();

            foreach (Match m in matches)
            {
                HashTag newHT;

                newHT = db.HashTags.Where(ht => ht.Name == m.Value).FirstOrDefault();

                if (newHT == null)
                {
                    newHT = new HashTag() { Name = m.Value, Id = Guid.NewGuid() };

                    db.HashTags.Add(newHT);
                    db.SaveChanges();
                }

                post.HashTags.Add(newHT);
            }
        }

        private void AddUserLike(ApplicationUser user, Post post, bool likes)
        {
            db.AspNetUserLikes.Add(
                new AspNetUserLike()
                {
                    AspNetUser = user,
                    Post = post,
                    Likes = likes,
                    Dislikes = !likes
                }
            );

            if (likes)
            {
                ++post.Likes;
            }
            else
            {
                ++post.Dislikes;
            }

            db.SaveChanges();
        }

        private void EditUserLike(ApplicationUser user, Post post, AspNetUserLike like, bool likes)
        {

            if (like != null)
            {
                if (like.Likes == likes)
                {
                    return;
                }
                else
                {
                    like.Likes = likes;
                    like.Dislikes = !likes;

                    if (likes)
                    {
                        post.Likes++;
                        post.Dislikes--;
                    }
                    else
                    {
                        post.Likes--;
                        post.Dislikes++;
                    }
                }
            }

            db.SaveChanges();
        }

        // GET: Posts
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {

            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,CreatedAt,Likes")] Post post)
        {
            if (ModelState.IsValid)
            {
                string crntUserId = User.Identity.GetUserId();
                ApplicationUser crntUser = db.Users.FirstOrDefault(x => x.Id == crntUserId);

                post.AspNetUserId = crntUser;
                filterPostHashtags(post);
                db.Posts.Add(post);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Content,CreatedAt,Likes")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Home()
        {
            ViewBag.Header = "All Posts";

            IList<Post> posts = db.Posts.ToList();
            IList<ApplicationUser> postUsers = db.Posts.Select(p => p.AspNetUserId).ToList();

            foreach (var post in posts)
            {
                post.AspNetUserId = postUsers.FirstOrDefault(u => u.Id == post.AspNetUserId.Id);
            }
            
            return View(posts);
        }

        [HttpGet]
        public ActionResult SearchByHashTag()
        {

            return View();
        }

        // GET /Posts/ByHashTag/{hashTag}
        [HttpGet]
        public ActionResult ByHashTag(string hashTag)
        {

            if (hashTag == null)
            {

                return RedirectToAction("Index", "Home");
            }

            HashTag givenHashTag = db.HashTags.Where(ht => ht.Name == hashTag).FirstOrDefault();

            if (givenHashTag != null)
            {
                ViewBag.Header = string.Format("Posts With Hashtag \"{0}\"", hashTag);
                IList<Post> posts = givenHashTag.Posts.ToList();

                return View("Home", posts);
            }
            else
            {
                ViewBag.Header = string.Format("No Posts Found With Hashtag \"{0}\"", hashTag);

                return View("Home", new List<Post>());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Like(Post post, bool likes)
        {
            string crntUserId = User.Identity.GetUserId();
            ApplicationUser crntUser = db.Users.FirstOrDefault(x => x.Id == crntUserId);

            Post crntPost = db.Posts.FirstOrDefault(p => p.Id == post.Id);

            AspNetUserLike userLike = db.AspNetUserLikes.FirstOrDefault(
                l =>
                    l.AspNetUser.Id == crntUser.Id &&
                    l.Post.Id == post.Id
            );

            if (userLike != null)
            {
                EditUserLike(crntUser, crntPost, userLike, likes);
            }
            else
            {
                AddUserLike(crntUser, crntPost, likes);
            }

            return RedirectToAction("Home", "Posts");
        }
    }
}
