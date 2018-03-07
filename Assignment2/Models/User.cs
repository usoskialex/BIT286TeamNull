using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Assignment2.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "Email Address")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        [Required] 
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required (ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Updates")]
        public bool EmailUpdates { get; set; }

        [Display(Name = "Program ID")]
        public int ProgramID { get; set; }

        [Display(Name = "Logged In")]
        public bool LoggedIn { get; set; }

        public ICollection<Program> ChoseProgram { get; set; }

    }
}