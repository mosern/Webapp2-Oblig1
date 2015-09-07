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

            return View(irepository.GetAllBlogs());
        }

        [HttpGet]
        public ActionResult Blog(int BlogsID)
        {
            ViewBag.BlogId = BlogsID;
            ViewBag.Title = irepository.GetBlogName(BlogsID);
            ViewBag.Description = irepository.GetBlogDescription(BlogsID);

            var Posts = irepository.GetAllPosts(irepository.GetBlog(BlogsID), 5);
            return View(Posts);
        }
        
        public ActionResult NewPost(int? id)
        {
            try
            {
                ViewBag.isIdNull = false;
                return View(new Posts {BlogsID = id.Value });
            }
            catch
            {
                ViewBag.isIdNull = true;
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult NewPost([Bind(Include = "BlogsId, Header, Content, Created, CreatedBy")]Posts newPosts, int id)
        {
            newPosts.BlogsID = id;
            newPosts.CreatedBy = "Bruker";
            newPosts.Created = DateTime.Now;
            newPosts.LastEdited = DateTime.Now;
            irepository.AddPost(newPosts);

            return RedirectToAction("List");

        }

        public ActionResult EditPost(int? id)
        {
            try
            {
                ViewBag.isIdNull = false;
                return View(irepository.GetPost(id.Value));
            }
            catch
            {
                ViewBag.isIdNull = true;
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditPost([Bind(Include = "Header, Content,Created, CreatedBy")]Posts post, int id)
        {
            post.PostsID = id;
            post.LastEdited = DateTime.Now;
            post.EditedBy = "BrukerE";
            irepository.UpdatePost(post);

            return RedirectToAction("List");
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

        public ActionResult Test()
        {
            return View(irepository.GetBlog(2));
        }

    }
}