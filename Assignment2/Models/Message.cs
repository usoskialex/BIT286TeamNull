using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Message
    {
        //model for message
        [Key]
        public int MessageID { get; set; }

        [Required(ErrorMessage = "Enter the message please")]
        public string MessageText { get; set; }

        // Property represent the entity relationship: "A Message has a sender"
        public virtual User Sender { get; set; }

        // Property represent the entity relationship: "A Message has a receiver"
        public virtual User Receiver { get; set; }

    }
}