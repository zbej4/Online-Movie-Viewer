using System.Web;
using System.Web.Mvc;

namespace Project_2___Online_Movie_Viewer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters (GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
