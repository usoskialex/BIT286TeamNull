using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.ViewModels
{
    public class CreateAccount
    {
        [DisplayName("First Name:")]
        [Required]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "User Name:")]
        [Required]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Pal's Name:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}