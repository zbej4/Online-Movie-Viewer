using Project_2___Online_Movie_Viewer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_2___Online_Movie_Viewer.DataContexts
{
    public class MovieProfileTagsDb : DbContext
    {
        public MovieProfileTagsDb() : base("name=DefaultConnection")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<MovieProfileTag> MovieTags { get; set; }
    }
}