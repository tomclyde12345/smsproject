using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smsproject.Models;
using smsproject.ViewModel;

namespace smsproject.Controllers
{
    public class DivisionsController : Controller
    {
        private ApplicationDbContext db;

        public DivisionsController()
        {
            db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Divisions
        public ActionResult Index()
        {
            var division = db.Divisions.ToList();
            return View(division);
        
        }

        public ActionResult New()
        {
            var divisions = db.Divisions.ToList();
            var dv = new DivisionVM()
            {
                DivisionList = divisions
            };
            return View("New", dv);
        }
        public ActionResult Save(Division division)
        {
            if (division.Id == 0)
            {
                db.Divisions.Add(division);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Divisions");
        }
    }
}
