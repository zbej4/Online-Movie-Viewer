using Project_2___Online_Movie_Viewer.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_2___Online_Movie_Viewer.Models
{
    public class Profile
    {
        [Key]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        [UsState]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Zip Code must be 5 digits.")]
        public int Zip { get; set; }


    }
}
