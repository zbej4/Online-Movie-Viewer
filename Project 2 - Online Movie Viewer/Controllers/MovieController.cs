using Project_2___Online_Movie_Viewer.DataContexts;
using Project_2___Online_Movie_Viewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_2___Online_Movie_Viewer.Controllers
{
    public class MovieController : Controller
    {
        private MovieProfileTagsDb _db = new MovieProfileTagsDb();

        protected override void Dispose (bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        // GET: Movie
        public ActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
            var q = _db.Profiles.Find(User.Identity.Name);
            if (q == null)
            {
                return RedirectToAction("Create", "Profile");
            }
            ViewBag.Profile = q;
            var q1 = _db.MovieTags.Where(mt => mt.Email == User.Identity.Name);
            ViewBag.ViewedMovies = q1;
            return View(_db.Movies.ToList());
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = _db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //Get: Watch Movie
        public ActionResult Watch (int id)
        {
            Movie movie = _db.Movies.Find(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Watch(MovieProfileTag movieProfileTag)
        {
            if (ModelState.IsValid)
            {
                _db.MovieTags.Add(movieProfileTag);
                _db.SaveChanges();
                return RedirectToAction(movieProfileTag.Movie.IMDB_Url);
            }
            return View(movieProfileTag);
            
        }
    }
}