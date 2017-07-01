using Microsoft.AspNet.Identity.EntityFramework;
using Project_2___Online_Movie_Viewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_2___Online_Movie_Viewer.Data_Contexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb ()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static IdentityDb Create ()
        {
            return new IdentityDb();
        }
    }
}