using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bank.Models;

namespace bank.Controllers
{
    public class LogInsController : Controller
    {
        private LogInDBContext db = new LogInDBContext();

        // GET: LogIns
        public ActionResult Index()
        {
            return View(db.LogIns.ToList());
        }

        [HttpPost]
        public ActionResult Logging( string Login, string Paswrd)
        {
            LogIn baseLogin = db.LogIns.Find(Login);
            if (baseLogin == null)
            {
                return HttpNotFound();
            }
            if (Paswrd==baseLogin.Paswrd)
            {
                return View();
            }

            return RedirectToAction("Index");

        }

        // GET: LogIns/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // GET: LogIns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LogIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Login,Paswrd")] LogIn logInToCreate)
        {
            if (ModelState.IsValid)
            {
                db.LogIns.Add(logInToCreate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logInToCreate);
        }

        // GET: LogIns/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: LogIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Login,Paswrd")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logIn).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logIn);
        }

        // GET: LogIns/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LogIn logIn = db.LogIns.Find(id);
            if (logIn == null)
            {
                return HttpNotFound();
            }
            return View(logIn);
        }

        // POST: LogIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LogIn logIn = db.LogIns.Find(id);
            db.LogIns.Remove(logIn);
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
    }
}
