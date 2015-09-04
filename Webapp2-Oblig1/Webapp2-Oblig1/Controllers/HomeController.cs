using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Webapp2_Oblig1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            ViewBag.Message = "Bakrund til The Blogg Matrix";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "Hvordan kontakte meg - Hint:Bruk epost ;)";

            return View();
        }
    }
}