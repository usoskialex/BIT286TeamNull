using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamNullGame.Models
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

        //This is the students pet name.
        [Required]
        [Display(Name = "Pal's Name")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int GameId { get; set; }

        //public virtual ICollection<Student> Students { get; set; }
    }
}