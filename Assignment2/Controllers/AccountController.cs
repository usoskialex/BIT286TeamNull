using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TeamNullGame.Models;
using TeamNullGame.ViewModels;


namespace TeamNullGame.Controllers
{
    public class AccountController : Controller
    {
        VisitorLogContext db = new VisitorLogContext();

        // GET: Account
        public ActionResult Results()
        {
            return View(db.Games);
        }

        //Get's the Create Student Page
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        //After student creates their account, will redirect to Login page
        [HttpPost]
        public ActionResult Create(Student student)
        {  
            db.Students.Add(student);
            db.SaveChanges();
            return RedirectToAction("StudentLogin");
        }

        [HttpGet] //prepare data for the view for the teacher
        public ActionResult Login()
        {
            int userIDnum = db.Users.Max(x => x.UserID);

            for (int y = 0; y < userIDnum; y++)
            {
                var log = db.Users.SingleOrDefault(x => x.LoggedIn == true && x.UserID == y);

                if (log != null)
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
            User student = new User();

            Activity Act = new Activity();

            User savedUser = db.Users.FirstOrDefault(m => m.Email == user.UserName && m.Password == user.Password);

            if (savedUser != null) //to check validity of the input
            {
                Act.ActivityName = user.UserName; //store the logged name
                Act.ActivityDate = DateTime.Now; //store current date and time
                Act.IpAddress = Request.UserHostAddress;// store user's IP adress


                db.Activities.Add(Act); //adding new user with name

                savedUser.LoggedIn = true;
                db.SaveChanges(); //saving new info in the database

                Session["TempUser"] = savedUser;

                return View("Results", db.Games); 
            }
            else
            {
                ModelState.Clear(); //to delete the input
                ModelState.AddModelError("Error", "Sorry. " +
                    "Check the database for login and password"); //display the error
                return View("Login");

            }

        }




        [HttpGet] //Login page for the student
        public ActionResult StudentLogin()
        {

            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(Student user)
        {
           
            var std = db.Students.Where(u => u.FirstName == user.FirstName && u.Password == user.Password).FirstOrDefault();

            if (std != null)
            {
                Session["StudentID"] = std.StudentID.ToString();
                Session["FirstName"] = std.FirstName.ToString();
                
                return RedirectToAction("Game", "Home");
            }
            
            else
            {
                ModelState.Clear(); //to delete the input
                ModelState.AddModelError("Error", "Sorry. " +
                    "Check the database for login and password"); //display the error
                return View("StudentLogin");
            }

        }


        [HttpGet]
        public ActionResult Welcome()
        {
            
            return View();
        }

        //[HttpPost]
        //public ActionResult Welcome(string submitButton)
        //{
        //    switch (submitButton)
        //    {
        //        case "SendT":
        //            return View("Login");
        //        case "SendS":
        //            return View("StudentLogin");

        //    }
        //    return View();
        //}



        //[HttpGet]
        //public ActionResult PasswordReset()
        //{
        //    return View();
        //}

        ////Password reset for the student
        //[HttpPost]
        //public ActionResult PasswordReset(Student user)
        //{
        //    UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>());

        //    userManager.RemovePassword(StudentID);

        //    userManager.AddPassword(StudentID, newPassword);

        //    return View("StudentLogin");
        //}


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