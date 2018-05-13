using Assignment2.Models;
using Assignment2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
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
            //var currentstudent = new Student();
            ////Get the current player from the Database
            int id = Convert.ToInt32(Session["StudentID"]);
            var currentstudent = vl.Students.SingleOrDefault(s=>s.StudentID ==id);
            Session["StudentID"] = currentstudent.StudentID;
           

            //Session["PalsName"] = currentstudent.Password;
            GameViewModel myGame = new GameViewModel();
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

            int id = Convert.ToInt32(Session["StudentID"]);
            var currentstudent = vl.Students.SingleOrDefault(s => s.StudentID == id);
            //Get the current player from the Database

            Game currentGame = new Game();

            currentGame.studentID = currentstudent.StudentID;


            if (Convert.ToUInt32(Session["Answer"]) == Convert.ToUInt32(Session["Guess"]))
            {
              
                //add to total correct answers
                currentGame.TotalCorrect++;
                vl.Games.Add(currentGame);
                ////save to database
                vl.SaveChanges();
                Session["TotalCorrect"] = currentGame.TotalCorrect;
                //redirect to winning page with reward
                return RedirectToAction("Index");
            }
            else
            {   //add to incorrect total answers
                currentGame.TotalIncorrect++;
                vl.Games.Add(currentGame);
                //save to database
                vl.SaveChanges();
                //replay game
                ViewBag.Message = "Sorry, try again";
                return View(game);
            }



        }
    }
}