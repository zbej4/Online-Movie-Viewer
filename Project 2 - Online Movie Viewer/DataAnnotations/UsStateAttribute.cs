using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_2___Online_Movie_Viewer.DataAnnotations
{
    sealed public class UsStateAttribute : ValidationAttribute
    {
        private readonly string[] validStateAbbr = new string[] { "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DC", "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY" };

        public UsStateAttribute () : base("must be a valid two character U.S. State abbreviation.")
        {
        }

        public override string FormatErrorMessage (string name)
        {
            return String.Format("{0} {1}", name, ErrorMessageString);
        }

        public override bool IsValid (object value)
        {
            bool isValid = false;
            if (!String.IsNullOrWhiteSpace(value.ToString()))
            {
                if (value.ToString().Length == 2 && this.validStateAbbr.Contains(value.ToString()))
                {
                    isValid = true;
                }
            }
            return isValid;
        }


    }
}