namespace Project_2___Online_Movie_Viewer.DataContexts.MovieProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovieProfileTags", "Tag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieProfileTags", "Tag", c => c.String(nullable: false));
        }
    }
}
