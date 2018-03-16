using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.ViewModels;
//BIT 285
//Aliaksandr Usoski
//Assignment 2
//March 7, 2018

namespace Assignment2.Controllers
{
    public class AccountController : Controller
    {
        VisitorLogContext db = new VisitorLogContext();
        Random rnd = new Random(); //random object
        string randomLN;
        string randomColor;

        // GET: Account
        public ActionResult Index()
        {
            return View(db.Activities);
        }

        [HttpGet] //prepare data for the view
        public ActionResult Login()
        {
            int userIDnum = db.Users.Max(x => x.UserID); //to 

            for(int y = 0; y < userIDnum; y++)
            {
                var log = db.Users.SingleOrDefault(x => x.LoggedIn == true && x.UserID == y);

                if(log != null)
                {
                    log.LoggedIn = false;
                    db.SaveChanges();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            
            Activity Act = new Activity();

            User savedUser = db.Users.SingleOrDefault(m => m.Email == user.UserName && m.Password == user.Password);

            if (savedUser != null) //to check validity of the input
            {
                Act.ActivityName = user.UserName; //store the logged name
                Act.ActivityDate = DateTime.Now; //store current date and time
                Act.IpAddress = Request.UserHostAddress;// store user's IP adress


                db.Activities.Add(Act); //adding new user with name, login and ip into table
              
                savedUser.LoggedIn = true;
                db.SaveChanges(); //saving new info in the database

                Session["TempUser"] = savedUser;

                return View("Index", db.Activities); //returning view and database
            }
            else
            {
                ModelState.Clear(); //to delete the input
                ModelState.AddModelError("Error", "Sorry. " +
                    "Cannot find information about you in system! You should create new account!"); //display the error
                return View("Login");
             
            }

        }


        [HttpGet]
        public ActionResult NewAccount() //new Account page
        {
            var model = new NewAccInfoViewModel(); //instance of a viewmodel
            model.ChosePrograms = db.Programs; 
            return View(model); //To display models
        }


        [HttpPost]
        public ActionResult NewAccount(NewAccInfoViewModel newAcc)
        {

            SessionUser().FirstName = newAcc.FirstName; //putting info about user into session
            SessionUser().LastName = newAcc.LastName;
            SessionUser().Email = newAcc.Email;
            SessionUser().Programs = newAcc.Program;
            SessionUser().EmailUpdates = newAcc.EmailUpd;

            return RedirectToAction("PasswordCreation");
        }


        [HttpGet]
        public ActionResult PasswordCreation()
        {
            PasswordViewModel passinst = new PasswordViewModel(); //instance of the password viewmodel

            passinst.PassOptions = new List<string>();
            passinst.PassOptions.Add("Suggest A Password");
            passinst.LastName = SessionUser().LastName; //grabbing lastname from the newaccount

            return View(passinst);
        }


        [HttpPost]
        public ActionResult PasswordCreation(PasswordViewModel pass)
        {

                switch (Request["submit"]) //cases for different buttons
                {
                case "Generate Password":
                        pass.PassOptions = new List<string>(); 
                        List<string> passlist = passwordsL(pass);

                    foreach (string password in passlist) 
                    {
                        pass.PassOptions.Add(password); //adding each password to a viewmodel
                    }
                    break;

                case "Create Account":

                    User temp = new User();

                    temp = SessionUser();

                    temp.Password = pass.Passwords;

                    db.Users.Add(temp); //adding user to the database

                    db.SaveChanges(); //save database

                    return RedirectToAction("ConfirmationPage"); //redirects to the confirmation page

                }

            return View(pass);
        }

        [HttpGet]
        public ActionResult ConfirmationPage(User temp)
        {
            temp = SessionUser();
            ViewBag.Message = temp.FirstName + " " + temp.LastName + ", " +
                "Congrats! You registered in system!"; //displaying message
            return View(db.Users); //showing the table with last name and passwords
        }

        [HttpPost]
        public ActionResult ConfirmationPage()
        {

            return View(db.Users);
        }




        private List<string> passwordsL(PasswordViewModel pass) //list for suggested passwords
        {
            string lastName = pass.LastName.ToString(); //creating instances of the strings based on fields input
            string birthYear = pass.BirthYear.ToString();
            string favColor = pass.Color.ToString();


            char[] firstRand = pass.LastName.ToCharArray(); 
            char[] secondRand = pass.Color.ToCharArray();

            for (int i = 0; i < 4; i++) //I think it'll be more secure then using simple string concatinations
            {
                randomLN += firstRand[rnd.Next(firstRand.Length)].ToString();  //taking 4 random letters from the last name field input based on seed value
                randomColor += secondRand[rnd.Next(secondRand.Length)].ToString();
            }

            string PO1 = ((birthYear + favColor + randomLN).Replace(" ", String.Empty)).ToString();          //passwords + bonus (removed whitespaces in passwords)
            string P02 = ((lastName + birthYear + randomLN).Replace(" ", String.Empty)).ToString();
            string P03 = ((randomColor + lastName).Replace(" ", String.Empty)).ToString();
            string P04 = ((randomColor + randomColor + favColor).Replace(" ", String.Empty)).ToString();
            string P05 = ((birthYear + randomLN + lastName).Replace(" ", String.Empty)).ToString();

            var passwords = new List<string> { PO1, P02, P03, P04, P05 };

            return passwords; 
        }        

        private User SessionUser() //storing temp user in session
        {
            if (Session["tempUser"] == null)
            {
                Session["tempUser"] = new User();
            }
            return (User)Session["tempUser"];
        }

        private void DeleteTempUser()
        {
            Session.Remove("tempUser");
        }
    }
}