namespace Project_2___Online_Movie_Viewer.DataContexts.MovieProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondaryCreate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MovieProfileTags", "Tag", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MovieProfileTags", "Tag");
        }
    }
}
