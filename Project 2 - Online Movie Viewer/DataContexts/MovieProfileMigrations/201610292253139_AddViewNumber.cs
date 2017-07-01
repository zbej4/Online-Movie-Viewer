namespace Project_2___Online_Movie_Viewer.DataContexts.MovieProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddViewNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieProfileTags", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieProfileTags", "Views");
        }
    }
}
