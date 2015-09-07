using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Webapp2_Oblig1.Models;

namespace Webapp2_Oblig1.Controllers
{
    public class DbRepository : IRepository
    {
        private DbModel db = new DbModel();

        public void RemovePost(Posts post)
        {
            try
            {
                db.Posts.Remove(post);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public void UpdatePost(Posts post)
        {
            try
            {
                Posts orgin = db.Posts.Where(p => p.PostsID == post.PostsID).Single();
                orgin.Header = post.Header;
                orgin.Content = post.Content;
                orgin.LastEdited = post.LastEdited;
                orgin.EditedBy = post.EditedBy;
                orgin.Edited = true;

                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public List<Blogs> GetAllBlogs()
        {
            try
            {
                return db.Blogs.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public List<Posts> GetAllPosts()
        {
            try
            {
                return db.Posts.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public List<Posts> GetAllPosts(Blogs blog)
        {
            try
            {
                return db.Posts.Where(p => p.BlogsID == blog.BlogsID).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public List<Posts> GetAllPosts(int count)
        {
            try
            {
                return db.Posts.OrderBy(p => p.Created).Take(count).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public List<Posts> GetAllPosts(Blogs blog, int count)
        {
            try
            {
                return db.Posts.Where(p => p.BlogsID == blog.BlogsID).OrderByDescending(p => p.Created).Take(count).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public Blogs GetBlog(int BlogId)
        {
            try
            {
                return db.Blogs.Where(p => p.BlogsID == BlogId).Single();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public string GetBlogDescription(int BlogId)
        {
            try
            {
                return db.Blogs.Where(p => p.BlogsID == BlogId).Single().Description;
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public string GetBlogName(int BlogId)
        {
            try
            {
                return db.Blogs.Where(p => p.BlogsID == BlogId).Single().Name;
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public Posts GetPost(int PostId)
        {
            try
            { 
                return db.Posts.Where(p => p.PostsID == PostId).Single();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }

        public void AddPost(Posts post)
        {
            try
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.InnerException.Message);
            }
        }
    }
}