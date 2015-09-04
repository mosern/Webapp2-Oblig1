using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webapp2_Oblig1.Models;

namespace Webapp2_Oblig1.Controllers
{
    public class BlogsController : Controller
    {
        DbModel db = new DbModel();
        // GET: Blogger
        public ActionResult List()
        {
            ViewBag.Title = "Blogger";

            return View(db.Blogs);
        }
    }
}