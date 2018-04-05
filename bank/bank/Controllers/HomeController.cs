using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bank.Models;
using bank.Migrations;

namespace bank.Controllers
{
    public class HomeController : Controller
    {
        private LogInDBContext db = new LogInDBContext();
        public ActionResult Index()
        {


            HttpContext.Session["layout"] = "_Layout.cshtml";
            if (db.LogIns == null || db.LogIns.Count() == 0)
            {
                Configuration.Updating(db);
                db.SaveChanges();
            }
            return View();
        }

    }
}