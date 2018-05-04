﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        //This is the students pet name.
        [Required]
        [Display(Name = "Pal's Name")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}