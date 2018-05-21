using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeamNullGame.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string UserName { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public string Error { get; set; } // to display error on screen 
        //if there are no registered user in database
    }
}