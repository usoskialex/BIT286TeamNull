using Assignment2.Models;
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
        [HttpGet]
        public ActionResult Game()

        {
            Game myGame = new Game();
            Session["Number"] = myGame.Number;
            Session["Number2"] = myGame.Number2;
            Session["Number3"] = myGame.Number3;
            Session["Number4"] = myGame.Number4;
            Session["Answer"] = myGame.Answer;
            return View(myGame);


        }
        [HttpPost]
        public ActionResult Game(Game game)
        {
            Session["Guess"] = game.Guess;
            //game.UserName = "email@my.com";
            //game.LoginTime = DateTime.Now;
            //game.IpAddress = Request.UserHostAddress;

            if (Convert.ToUInt32(Session["Answer"]) == Convert.ToUInt32(Session["Guess"]))
            {
                ViewBag.Message = "Great Job!";
                //add to total correct answers
                game.TotalCorrect++;
                //save to database
                vl.SaveChanges();
                Session["TotalCorrect"] = game.TotalCorrect;
                //redirect to winning page with reward
                return RedirectToAction("Index");
            }
            else
            {   //add to incorrect total answers
                game.TotalIncorrect++;
                //save to database
                vl.SaveChanges();
                //replay game
                ViewBag.Message = "Sorry, try again";
                return View();
            }



        }
    }
}