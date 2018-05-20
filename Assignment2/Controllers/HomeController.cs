using TeamNullGame.Models;
using TeamNullGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TeamNullGame.Controllers
{
    public class HomeController : Controller
    {
        VisitorLogContext vl = new VisitorLogContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GameViewModel game)
        {
            
            return RedirectToAction("Game");
        }

        [HttpGet]
        public ActionResult Game(Student student)

        {
            GameViewModel myGame = new GameViewModel();
           
            //Game currentGame = new Game();
            //var currentstudent = new Student();
            ////Get the current player from the Database
            int id = Convert.ToInt32(Session["StudentID"]);
            var currentstudent = vl.Students.SingleOrDefault(s=>s.StudentID ==id);
            Session["StudentID"] = currentstudent.StudentID;
            
            Session["GameId"] = myGame.GameId;
            Session["Number"] = myGame.Number;
            Session["Number2"] = myGame.Number2;
            Session["Number3"] = myGame.Number3;
            Session["Number4"] = myGame.Number4;
            Session["Answer"] = myGame.Answer;

            return View(myGame);


        }
        [HttpPost]
        public ActionResult Game(GameViewModel game)
        {
            Session["Guess"] = game.Guess;

            //Get the current player from the Database
            int id = Convert.ToInt32(Session["StudentID"]);
            var currentstudent = vl.Students.SingleOrDefault(s => s.StudentID == id);

            //get the currentgame for the student
            var currentGame = vl.Games.SingleOrDefault(g => g.studentID ==currentstudent.StudentID);

            if (currentGame != null)
            {
            int gameid = currentGame.GameId;
            int totalCorrect = currentGame.TotalCorrect;
            int totalIncorrect = currentGame.TotalIncorrect;

            }

            if (currentGame == null)
            {
                currentGame = new Game();
                currentGame.studentID = currentstudent.StudentID;
                currentGame.TotalCorrect = 0;
                currentGame.TotalIncorrect = 0;
                vl.Games.Add(currentGame);
                vl.SaveChanges();
                currentstudent.GameId = currentGame.GameId;
            }


            if (Convert.ToUInt32(Session["Answer"]) == Convert.ToUInt32(Session["Guess"]))
            {

                //add to total correct answers
                currentGame.TotalCorrect++;
   
                vl.SaveChanges();
                Session["TotalCorrect"] = currentGame.TotalCorrect;
                ModelState.Clear();
                //redirect to winning page with reward
                return View();
            }
            else
            {   //add to incorrect total answers
                currentGame.TotalIncorrect++;

                vl.SaveChanges();
                Session["TotalIncorrect"] = currentGame.TotalIncorrect;
                //replay game
                ModelState.Clear();
                ViewBag.Message = "Sorry, try again";
                return View();
            }



        }
    }
}