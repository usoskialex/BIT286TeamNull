using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }

        public int TotalCorrect { get; set; }
        public int TotalIncorrect { get; set; }

        public int studentID { get; set; }
    }
}