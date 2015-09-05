using System;
using System.Collections.Generic;
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

        public void UpdatePost(int postID)
        {
            throw new NotImplementedException();
        }

        public List<Blogs> GetAllBlogs()
        {
            throw new NotImplementedException();
        }

        public List<Posts> GetAllPosts()
        {
            throw new NotImplementedException();
        }

        public List<Posts> GetAllPosts(Blogs blog)
        {
            throw new NotImplementedException();
        }

        public List<Posts> GetAllPosts(int count)
        {
            throw new NotImplementedException();
        }

        public List<Posts> GetAllPosts(Blogs blog, int count)
        {
            throw new NotImplementedException();
        }

        public Blogs GetBlog(int BlogId)
        {
            throw new NotImplementedException();
        }

        public string GetBlogDescription(int BlogId)
        {
            throw new NotImplementedException();
        }

        public string GetBlogName(int BlogId)
        {
            throw new NotImplementedException();
        }

        public Posts GetPost(int PostId)
        {
            var querry = db.Posts.Where(p => p.PostsID == PostId);
            return querry.ToList()[0];
        }

        public void AddPost(Posts post)
        {
            throw new NotImplementedException();
        }
    }
}