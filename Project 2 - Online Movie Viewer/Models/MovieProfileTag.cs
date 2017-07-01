using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_2___Online_Movie_Viewer.Models
{
    public class MovieProfileTag
    {
        [Key]
        [ForeignKey("Movie")]
        [Column(Order = 1)]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [Key]
        [ForeignKey("Profile")]
        [Column(Order = 2)]
        public string Email { get; set; }
        public virtual Profile Profile { get; set; }

        public string Tag { get; set; }

        public int Views { get; set; }
    }
}