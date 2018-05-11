using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.ViewModels
{
    public class StudentLoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Pal's Name")]
        public string Password { get; set; }

        public string Error { get; set; } // to display error on screen if there are no registered user in database
    }
}