using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_2___Online_Movie_Viewer.Startup))]
namespace Project_2___Online_Movie_Viewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
