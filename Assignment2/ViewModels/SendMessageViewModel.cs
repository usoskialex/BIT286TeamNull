using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.ViewModels
{
    public class SendMessageViewModel
    {

        public int ReceiverID { get; set; }

        public User Receiver { get; set; }

        public string Message { get; set; }

        public ICollection<User> Users { get; set; } //collection of users
    }
}