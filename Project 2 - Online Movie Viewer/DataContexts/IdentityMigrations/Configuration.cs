namespace Project_2___Online_Movie_Viewer.DataContexts.IdentityMigrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Project_2___Online_Movie_Viewer.Data_Contexts.IdentityDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\IdentityMigrations";
        }

        protected override void Seed(Project_2___Online_Movie_Viewer.Data_Contexts.IdentityDb context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Customer"))
            {
                roleManager.Create(new IdentityRole { Name = "Customer" });
            }


            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName == "admin@user.com"))
            {
                var user = new ApplicationUser
                {
                    Email = "admin@user.com",
                    UserName = "admin@user.com"
                };
                userManager.Create(user, "Pass123!");
                userManager.AddToRole(user.Id, "Admin");
            }

        }
    }
}
