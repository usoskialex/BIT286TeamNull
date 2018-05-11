using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment2.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Display(Name = "Email Address")]

        [Required(ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "First Name is required!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Updates")]
        public bool EmailUpdates { get; set; }

        [Display(Name = "Logged In")]
        public bool LoggedIn { get; set; }

        public string Fullname { get { return string.Format("{0}, {1}", LastName, FirstName); } }


        // Property represent the entity relationship: "A User can have many Activities"
        public virtual ICollection<Activity> Activities { get; set; }
    }
}