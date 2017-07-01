namespace Project_2___Online_Movie_Viewer.DataContexts.MovieProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfileId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieProfileTags", "Email", "dbo.Profiles");
            DropIndex("dbo.MovieProfileTags", new[] { "Email" });
            RenameColumn(table: "dbo.MovieProfileTags", name: "Email", newName: "ProfileId");
            DropPrimaryKey("dbo.MovieProfileTags");
            DropPrimaryKey("dbo.Profiles");
            AddColumn("dbo.Profiles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.MovieProfileTags", "ProfileId", c => c.Int(nullable: false));
            AlterColumn("dbo.Profiles", "Email", c => c.String());
            AddPrimaryKey("dbo.MovieProfileTags", new[] { "MovieId", "ProfileId" });
            AddPrimaryKey("dbo.Profiles", "Id");
            CreateIndex("dbo.MovieProfileTags", "ProfileId");
            AddForeignKey("dbo.MovieProfileTags", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieProfileTags", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.MovieProfileTags", new[] { "ProfileId" });
            DropPrimaryKey("dbo.Profiles");
            DropPrimaryKey("dbo.MovieProfileTags");
            AlterColumn("dbo.Profiles", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.MovieProfileTags", "ProfileId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Profiles", "Id");
            AddPrimaryKey("dbo.Profiles", "Email");
            AddPrimaryKey("dbo.MovieProfileTags", new[] { "MovieId", "Email" });
            RenameColumn(table: "dbo.MovieProfileTags", name: "ProfileId", newName: "Email");
            CreateIndex("dbo.MovieProfileTags", "Email");
            AddForeignKey("dbo.MovieProfileTags", "Email", "dbo.Profiles", "Email", cascadeDelete: true);
        }
    }
}
