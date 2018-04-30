using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Activity
    {
        //model for logged user
        public int ActivityID { get; set; }
        [Display(Name = "Name")]
        public string ActivityName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ActivityDate { get; set; }
        public string IpAddress { get; set; }
    }
}