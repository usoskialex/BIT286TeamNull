using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//BIT 285
//Aliaksandr Usoski
//Assignment 2
//March 7, 2018

namespace Assignment2.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string Error { get; set; } // to display error on screen if there are no registered user in database
    }
}