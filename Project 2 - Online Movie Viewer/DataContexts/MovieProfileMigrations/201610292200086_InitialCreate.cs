namespace Project_2___Online_Movie_Viewer.DataContexts.MovieProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Year = c.Int(nullable: false),
                        LengthInMinutes = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        IMDB_Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieProfileTags",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 128),
                        Tag = c.String(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieId, t.Email })
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Email, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Email = c.String(nullable: false, maxLength: 128),
                        Username = c.String(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        StreetAddress = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Zip = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Email);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieProfileTags", "Email", "dbo.Profiles");
            DropForeignKey("dbo.MovieProfileTags", "MovieId", "dbo.Movies");
            DropIndex("dbo.MovieProfileTags", new[] { "Email" });
            DropIndex("dbo.MovieProfileTags", new[] { "MovieId" });
            DropTable("dbo.Profiles");
            DropTable("dbo.MovieProfileTags");
            DropTable("dbo.Movies");
        }
    }
}
