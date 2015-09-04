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
                p => p.Name,
                new Blogs { Created = DateTime.Now, Description = "Blog from seed", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg", Owner = "seed"},
                new Blogs { Created = DateTime.Now, Description = "Blog from seed2", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg2", Owner = "seed" },
                new Blogs { Created = DateTime.Now, Description = "Blog from seed3", IsOpen = true, LastEdited = DateTime.Now, LastEditor = "seed", Name = "TheSeedBlogg3", Owner = "seed" }
            );

            context.Posts.AddOrUpdate(
                p => new { p.Header, p.BlogsID },
                new Posts { BlogsID = 1, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed" },
                new Posts { BlogsID = 1, Content = "Seeded content2", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed2" },
                new Posts { BlogsID = 1, Content = "Seeded content3", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed3" },
                new Posts { BlogsID = 1, Content = "Seeded content4", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed4" },
                new Posts { BlogsID = 1, Content = "Seeded content5", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed5" },

                new Posts { BlogsID = 2, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed" },
                new Posts { BlogsID = 2, Content = "Seeded content2", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed2" },
                new Posts { BlogsID = 2, Content = "Seeded content3", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed3" },
                new Posts { BlogsID = 2, Content = "Seeded content4", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed4" },
                new Posts { BlogsID = 2, Content = "Seeded content5", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed5" },

                new Posts { BlogsID = 3, Content = "Seeded content", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed" },
                new Posts { BlogsID = 3, Content = "Seeded content2", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed2" },
                new Posts { BlogsID = 3, Content = "Seeded content3", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed3" },
                new Posts { BlogsID = 3, Content = "Seeded content4", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed4" },
                new Posts { BlogsID = 3, Content = "Seeded content5", Created = DateTime.Now, CreatedBy = "seed", LastEdited = DateTime.Now, Edited = false, Header = "Header from seed5" }
            );
            
        }
    }
}
