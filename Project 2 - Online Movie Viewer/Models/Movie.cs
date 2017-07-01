using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_2___Online_Movie_Viewer.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [RegularExpression(@"^\d{4}$", ErrorMessage = "Must be a 4 digit year.")]
        public int Year { get; set; }

        [Range(1,int.MaxValue)]
        public int LengthInMinutes { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(1.0, Double.MaxValue)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "URL")]
        [RegularExpression(@"(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?", ErrorMessage = "Not a valid URL.")]
        public string IMDB_Url { get; set; }

        public virtual ICollection<MovieProfileTag> MovieTags { get; set; }
    }
}