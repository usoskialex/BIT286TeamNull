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

        private Random _random = new Random();
        private int _number = 0;
        private int _number2 = 0;
        private int _number3 = 0;
        private int _number4 = 0;

        private int _answer = 0;

        public int Guess { get; set; }
        public int TotalCorrect { get; set; }
        public int TotalIncorrect { get; set; }


        public int Number
        {
            get
            {
                _number = _random.Next(1, 4);
                return _number;

            }
            set
            {
                return;
            }

        }

        public int Number2
        {
            get
            {
                _number2 = _random.Next(1, 10);


                return _number2;

            }
            set
            {
                return;
            }

        }
        public int Number3
        {
            get
            {
                _number3 = _random.Next(1, 4);


                return _number3;

            }
            set
            {
                return;
            }

        }
        public int Number4
        {
            get
            {
                _number4 = _random.Next(1, 10);


                return _number4;

            }
            set
            {
                return;
            }

        }
        public int Answer
        {
            get
            {
                _answer = _number2 + _number4;
                return _answer;
            }
            set
            {
                return;
            }

        }
    }
}