namespace Webapp2_Oblig1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialconfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogsID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Owner = c.String(),
                        IsOpen = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        LastEdited = c.DateTime(nullable: false),
                        LastEditor = c.String(),
                    })
                .PrimaryKey(t => t.BlogsID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostsID = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Content = c.String(),
                        CreatedBy = c.String(),
                        EditedBy = c.String(),
                        Created = c.DateTime(nullable: false),
                        LastEdited = c.DateTime(nullable: false),
                        Edited = c.Boolean(nullable: false),
                        BlogsID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostsID)
                .ForeignKey("dbo.Blogs", t => t.BlogsID, cascadeDelete: true)
                .Index(t => t.BlogsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "BlogsID", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogsID" });
            DropTable("dbo.Posts");
            DropTable("dbo.Blogs");
        }
    }
}
