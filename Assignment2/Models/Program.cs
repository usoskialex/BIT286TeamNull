using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Program
    {
        //model for dropdown list
        public int ProgramID { get; set; } 
        [Display(Name = "Program Option")]
        public string ProgramName { get; set; }

        public virtual Program ChoseProgram { get; set; }
    }
}