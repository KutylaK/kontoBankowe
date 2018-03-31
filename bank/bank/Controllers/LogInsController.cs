﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using bank.Helper;
using bank.Models;
using bank.Models.ViewModels;

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


        // GET: LogIns/Details/5
        public ActionResult Details(Guid id)
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
        public ActionResult Create(LogIn logInToCreate)
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
        public ActionResult Edit(Guid id)
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
        public ActionResult Edit(LogIn model)
        {
            if (ModelState.IsValid)
            {
                var en = db.LogIns.FirstOrDefault(_ => _.OId==model.OId);
                en.Paswrd = model.Paswrd;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
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

        public ActionResult Logging()
        {
            return View(new LogIn());
        }

        public ActionResult Logged()
        {
            var colect = from item in db.Przelewy
                         where item.Nadawca == AppHelper.CurrentUser.Login || item.Odbiorca == AppHelper.CurrentUser.Login
                         select item;
            var colorColect=new List<PrzelewColor>();
            foreach (var item in colect)
            {
                if(item.Nadawca == AppHelper.CurrentUser.Login)
                {
                    colorColect.Add(new PrzelewColor(item, "background-color:#cc0000"));
                }
                else
                {
                    colorColect.Add(new PrzelewColor(item, "background-color:#00cc00"));
                }
            }
            return View(colorColect);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePrzelew(Przelew zlecenie)
        {
            zlecenie.Nadawca=AppHelper.CurrentUser.Login;
            if (ModelState.IsValid)
            {
               
                db.Przelewy.Add(zlecenie);
                LogIn zrodlo = db.LogIns.FirstOrDefault(_ => _.Login == AppHelper.CurrentUser.Login);
                zrodlo.Saldo -= zlecenie.Stawka;
                AppHelper.CurrentUser.Saldo -= zlecenie.Stawka;
                LogIn cel = db.LogIns.FirstOrDefault(_ => zlecenie.Odbiorca==_.Login);
                cel.Saldo += zlecenie.Stawka;
                db.SaveChanges();
                return RedirectToAction("Logged");
            }

            return View(zlecenie);
        }

        public ActionResult CreatePrzelew()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoggingIn(LogIn model)
        {
            LogIn baseLogin = db.LogIns.FirstOrDefault(_ =>model.Login==_.Login);
            if (baseLogin == null)
            {
                return HttpNotFound();
            }
            if (model.Paswrd == baseLogin.Paswrd)
            {
                HttpContext.Session["user"] = baseLogin;
                return RedirectToAction("Logged");
            }

            return RedirectToAction("Index");

        }
    }
}
