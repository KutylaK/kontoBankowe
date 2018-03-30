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
    public class PrzelewsController : Controller
    {
        private PrzelewDBContext db = new PrzelewDBContext();

        // GET: Przelews
        public ActionResult Index()
        {
            return View(db.Przelewy.ToList());
        }

        // GET: Przelews/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przelew przelew = db.Przelewy.Find(id);
            if (przelew == null)
            {
                return HttpNotFound();
            }
            return View(przelew);
        }

        // GET: Przelews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Przelews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nadawca,Odiorca,Stawka")] Przelew przelew)
        {
            if (ModelState.IsValid)
            {
                db.Przelewy.Add(przelew);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(przelew);
        }

        

        // GET: Przelews/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przelew przelew = db.Przelewy.Find(id);
            if (przelew == null)
            {
                return HttpNotFound();
            }
            return View(przelew);
        }

        // POST: Przelews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Przelew przelew = db.Przelewy.Find(id);
            db.Przelewy.Remove(przelew);
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
