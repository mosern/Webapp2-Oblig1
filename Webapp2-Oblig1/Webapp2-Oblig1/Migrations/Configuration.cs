namespace Webapp2_Oblig1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Webapp2_Oblig1.Models.DbModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Webapp2_Oblig1.Models.DbModel context)
        {
            context.Blogs.AddOrUpdate(
                p => p.BlogsID,
                new Blogs { BlogsID = 1, Created = DateTime.Now, Description = "Blog from seed", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg", Owner = "seed"}
            );

            context.Posts.AddOrUpdate(
                p => p.BlogsID,
                new Posts { BlogsID = 1, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed", PostsID = 1}
            );
            
        }
    }
}
