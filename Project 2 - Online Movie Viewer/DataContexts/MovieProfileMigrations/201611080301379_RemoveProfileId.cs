namespace Project_2___Online_Movie_Viewer.DataContexts.MovieProfileMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProfileId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieProfileTags", "ProfileId", "dbo.Profiles");
            DropIndex("dbo.MovieProfileTags", new[] { "ProfileId" });
            RenameColumn(table: "dbo.MovieProfileTags", name: "ProfileId", newName: "Email");
            DropPrimaryKey("dbo.MovieProfileTags");
            DropPrimaryKey("dbo.Profiles");
            AlterColumn("dbo.MovieProfileTags", "Email", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Profiles", "Email", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.MovieProfileTags", new[] { "MovieId", "Email" });
            AddPrimaryKey("dbo.Profiles", "Email");
            CreateIndex("dbo.MovieProfileTags", "Email");
            AddForeignKey("dbo.MovieProfileTags", "Email", "dbo.Profiles", "Email", cascadeDelete: true);
            DropColumn("dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Profiles", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.MovieProfileTags", "Email", "dbo.Profiles");
            DropIndex("dbo.MovieProfileTags", new[] { "Email" });
            DropPrimaryKey("dbo.Profiles");
            DropPrimaryKey("dbo.MovieProfileTags");
            AlterColumn("dbo.Profiles", "Email", c => c.String());
            AlterColumn("dbo.MovieProfileTags", "Email", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Profiles", "Id");
            AddPrimaryKey("dbo.MovieProfileTags", new[] { "MovieId", "ProfileId" });
            RenameColumn(table: "dbo.MovieProfileTags", name: "Email", newName: "ProfileId");
            CreateIndex("dbo.MovieProfileTags", "ProfileId");
            AddForeignKey("dbo.MovieProfileTags", "ProfileId", "dbo.Profiles", "Id", cascadeDelete: true);
        }
    }
}
