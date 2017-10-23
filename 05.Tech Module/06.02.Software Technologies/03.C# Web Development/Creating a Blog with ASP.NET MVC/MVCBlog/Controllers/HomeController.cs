using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVCBlog.Controllers
{
    using MVCBlog.Models;

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            var posts = this.db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(3).ToList();
            return View(posts);
        }       
    }
}