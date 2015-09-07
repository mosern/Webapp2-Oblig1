using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Webapp2_Oblig1.Models;
using Webapp2_Oblig1.Controllers;
using Moq;
using System.Web.Mvc;
using System.Collections;

namespace Webapp2_Oblig1.Tests.Controllers
{
    [TestClass]
    public class BlogsControllerTest
    {
        private List<Blogs> blogs;
        private List<Posts> posts1;
        private List<Posts> posts2;
        private List<Posts> posts3;
        private Mock<IRepository> irepository;
        private BlogsController controller;
        private int id;

        [TestInitialize]
        public void Setup()
        {
            id = 1;

            blogs = new List<Blogs>{
                new Blogs { Created = DateTime.Now, Description = "Blog from seed", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg", Owner = "seed"},
                new Blogs { Created = DateTime.Now, Description = "Blog from seed2", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg2", Owner = "seed" },
                new Blogs { Created = DateTime.Now, Description = "Blog from seed3", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg3", Owner = "seed" }
            };

            posts1 = new List<Posts>
            {
                new Posts { BlogsID = 1, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed" },
                new Posts { BlogsID = 1, Content = "Seeded content2", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed2" },
                new Posts { BlogsID = 1, Content = "Seeded content3", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed3" },
                new Posts { BlogsID = 1, Content = "Seeded content4", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed4" },
                new Posts { BlogsID = 1, Content = "Seeded content5", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed5" },
            };

            posts2 = new List<Posts> {
                new Posts { BlogsID = 2, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed" },
                new Posts { BlogsID = 2, Content = "Seeded content2", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed2" },
                new Posts { BlogsID = 2, Content = "Seeded content3", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed3" },
                new Posts { BlogsID = 2, Content = "Seeded content4", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed4" },
                new Posts { BlogsID = 2, Content = "Seeded content5", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed5" },
            };

            posts3 = new List<Posts> {
                new Posts { BlogsID = 3, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed" },
                new Posts { BlogsID = 3, Content = "Seeded content2", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed2" },
                new Posts { BlogsID = 3, Content = "Seeded content3", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed3" },
                new Posts { BlogsID = 3, Content = "Seeded content4", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed4" },
                new Posts { BlogsID = 3, Content = "Seeded content5", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed5" }
            };

            irepository = new Mock<IRepository>();

            irepository.Setup(x => x.GetAllBlogs()).Returns(blogs);
            irepository.Setup(x => x.GetBlogName(It.IsAny<int>())).Returns(blogs[id].Name);
            irepository.Setup(x => x.GetBlogDescription(It.IsAny<int>())).Returns(blogs[id].Description);
            irepository.Setup(x => x.GetAllPosts(It.IsAny<Blogs>())).Returns(posts1);
            irepository.Setup(x => x.RemovePost(It.IsAny<Posts>()));
            irepository.Setup(x => x.UpdatePost(It.IsAny<int>(), It.IsAny<Posts>()));
            irepository.Setup(x => x.AddPost(It.IsAny<Posts>()));

            controller = new BlogsController(irepository.Object);
        }
        [TestMethod]
        public void GetAllBlogsIsCalledWhenListIsOpend()
        {
            controller.List();
            irepository.Verify(r => r.GetAllBlogs(), Times.Once);
        }

        [TestMethod]
        public void ListReturnBlogs()
        {
            controller.List();

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)controller.ModelState.Values, typeof(Blogs));
        }

        [TestMethod]
        public void GetBlogNameIsCalledWhenBlogIsOpend()
        {
            controller.Blog(It.IsAny<int>());

            irepository.Verify(r => r.GetBlogName(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetBlogDescriptionIsCalledWhenBlogIsOpend()
        {
            controller.Blog(It.IsAny<int>());

            irepository.Verify(r => r.GetBlogDescription(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void GetAllPostsIsCalledWhenBlogIsOpend()
        {
            controller.Blog(It.IsAny<int>());

            irepository.Verify(r => r.GetAllPosts(It.IsAny<Blogs>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void BlogReturnsPosts()
        {
            controller.Blog(It.IsAny<int>());

            CollectionAssert.AllItemsAreInstancesOfType((ICollection)controller.ModelState.Values, typeof(Posts));
        }

        [TestMethod]
        public void addPostIsCalledWhenNewPostIsCreated()
        {
            controller.NewPost(new Posts(), It.IsAny<int>());

            irepository.Verify(r => r.AddPost(It.IsAny<Posts>()), Times.Once);
        }

        [TestMethod]
        public void UpdatePostsIsCalledWhenPostIsEdited()
        {
            controller.EditPost(new Posts(), It.IsAny<int>());

            irepository.Verify(r => r.UpdatePost(It.IsAny<int>(), It.IsAny<Posts>()), Times.Once);
        }

        [TestMethod]
        public void RemovePostsIsCalledWhenPostIsDeleted()
        {
            controller.DeletePost(It.IsAny<int>());

            irepository.Verify(r => r.RemovePost(It.IsAny<Posts>()), Times.Once);
        }
    }
}
