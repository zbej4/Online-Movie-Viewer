using Project_2___Online_Movie_Viewer.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project_2___Online_Movie_Viewer.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private MovieProfileTagsDb _db = new MovieProfileTagsDb();

        protected override void Dispose (bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Index ()
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
            var q3 = _db.MovieTags.Where(mt => mt.Email == User.Identity.Name);
            return View(q3.ToList());            
        }

        public ActionResult About ()
        {
            return View();
        }
    }
}