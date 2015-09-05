﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webapp2_Oblig1.Models;

namespace Webapp2_Oblig1.Controllers
{
    public class BlogsController : Controller
    {
        IRepository irepository;

        public BlogsController()
        {
            irepository = new DbRepository();
        }

        public BlogsController(IRepository irepository)
        {
            this.irepository = irepository;
        }

        DbModel db = new DbModel();
        public ActionResult List()
        {
            ViewBag.Title = "Blogger";

            return View(db.Blogs);
        }

        [HttpGet]
        public ActionResult Blog(int BlogsID)
        {
            var BlogName = db.Blogs.Where(b => b.BlogsID == BlogsID).Select(b => b.Name);
            var BlogDesc = db.Blogs.Where(b => b.BlogsID == BlogsID).Select(b => b.Description);

            ViewBag.Title = BlogName.ToList<String>()[0];
            ViewBag.Description = BlogDesc.ToList<String>()[0];
            var Posts = db.Posts.Where(p => p.BlogsID == BlogsID);
            return View(Posts);
        }

        public ActionResult NewPost(Posts post)
        {
            throw new NotImplementedException();
        }

        public ActionResult EditPost(int postID)
        {
            throw new NotImplementedException();
        }
        public ActionResult DeletePost(int? id)
        {
            try
            {
                ViewBag.isIdNull = false;
                return View(irepository.GetPost(id.Value) as Posts);
            }
            catch(InvalidOperationException)
            {
                ViewBag.isIdNull = true;
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult DeletePost([Bind(Include="id")]int id)
        {
            irepository.RemovePost(irepository.GetPost(id));

            return RedirectToAction("List");
        }

    }
}