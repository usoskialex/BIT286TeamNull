using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.ViewModels;

namespace Assignment2.Controllers
{
    public class MessageController : Controller
    {
        private VisitorLogContext db = new VisitorLogContext();

        

        // GET: Message
        public ActionResult Index()
        {

            var tempUser = (User)Session["TempUser"];

            var lastUser = db.Messages.ToList().Where(x => x.Receiver.UserID == tempUser.UserID); 



            return View(lastUser);
        }

        // GET: Message/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            SendMessageViewModel instMess = new SendMessageViewModel(); 
            
            instMess.Users = db.Users.ToList();
            //instMess.Users = new List<string>();
            


            return View(instMess);
        }


        // POST: Message/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "MessageID,MessageText, Re")]*/ SendMessageViewModel Mess)
        {
            var instmessage = new Message();
            var receiver = db.Users.SingleOrDefault(x => x.UserID == Mess.ReceiverID);



            instmessage.MessageText = Mess.Message;

            //instmessage.Receiver = receiver;

            instmessage.Receiver = receiver;

            instmessage.Sender = (User)Session["TempUser"];

            db.Messages.Add(instmessage);
            db.SaveChanges();




            Activity activityThatMakesMeCry = new Activity(); //the best inst name for this assignment

            activityThatMakesMeCry.ActivityDate = DateTime.Now;

            activityThatMakesMeCry.ActivityName = "Message was sent to" + (User)Session["TempUser"];

            db.Activities.Add(activityThatMakesMeCry);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageID,MessageText")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Message/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Message/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
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
