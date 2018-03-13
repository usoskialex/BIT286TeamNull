using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Assignment2.Models;
//BIT 285
//Aliaksandr Usoski
//Assignment 2
//March 7, 2018

namespace Assignment2.ViewModels
{
    public class NewAccInfoViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public Program Program;

        public int ProgramID { get; set; }

        [Display(Name = "Program Options")]
        public string ProgramName { get; set; }

        [Display(Name = "Email me program updates")]
        public bool EmailUpd { get; set; }

        public IEnumerable <Program> ChosePrograms { get; set; } //property that contains programs I wanna display
    }
}