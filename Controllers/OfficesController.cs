using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smsproject.Models;
using smsproject.ViewModel;

namespace smsproject.Controllers
{
    public class OfficesController : Controller
    {
        private ApplicationDbContext db;

        public OfficesController()
        {
            db= new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        // GET: Offices
        public ActionResult Index()
        {
            var office = db.Offices.ToList();
            return View(office);
          
        }
        public ActionResult New()
        {
            var office = db.Offices.ToList();
            var vm = new OfficeVM
            {
                OfficeList = office
            };
            return View("New",vm);

        }
        public ActionResult Save(Offices offices)
        {
            if (offices.Id == 0)
            {
                db.Offices.Add(offices);
            }

            db.SaveChanges();
            return RedirectToAction("Index", "Offices");
        }
    }
}