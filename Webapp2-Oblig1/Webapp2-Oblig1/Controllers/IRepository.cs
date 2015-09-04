using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webapp2_Oblig1.Models;

namespace Webapp2_Oblig1.Controllers
{
    public interface IRepository
    {
        #region Blog Get
        Blogs GetBlog(int BlogId);
        List<Blogs> GetAllBlogs();
        String GetBlogName(int BlogId);
        String GetBlogDescription(int BlogId);
        #endregion

        #region Post Get
        Posts GetPost(int PostId);
        List<Posts> GetAllPosts();
        List<Posts> GetAllPosts(int count);
        List<Posts> GetAllPosts(Blogs blog);
        List<Posts> GetAllPosts(Blogs blog, int count);
        #endregion

        #region CRUD
        void AddPost(Posts post);
        void RemovePost(int postID);
        void UpdatePost(int postID);
        #endregion


    }
}
