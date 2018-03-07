using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.ViewModels
{
    public class PasswordViewModel
    {
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public string BirthYear { get; set; }

        [Required]
        [Display(Name = "Favorite Color")]
        public string Color { get; set; }

        public string Passwords { get; set; }

        [Display(Name = "Suggested Passwords: ")]
        //public SelectList PassOptions { get; set; }


        //public IEnumerable<SelectListItem> PassOptions { get; set; } //property that contains recommended passwords
        //public string UserChoice { get; set; }

        public List<string> PassOptions { get; set; }
    }
}