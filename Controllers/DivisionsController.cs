using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smsproject.Models;
using smsproject.ViewModel;

namespace smsproject.Controllers
{
    public class DivisionsController : Controller
    {
        // GET: Divisions

        private ApplicationDbContext ctx;

        public DivisionsController()
        {
            ctx = new ApplicationDbContext();
        }

        public ActionResult New()
        {
            var offices = ctx.Offices.ToList();
            var vm = new DivisionsVM()
            {
                OfficesList = offices
            };

            return View("Create", vm);

        }
        public ActionResult Index()
        {
            var divs = ctx.Divisions.Include(d => d.Offices).ToList();
            return View(divs);
        }

        [HttpPost]
        public ActionResult Save(Divisions divisions)
        {
            if (divisions.Id == 0)
            {
                ctx.Divisions.Add(divisions);
            }

            ctx.SaveChanges();
            return RedirectToAction("Index", "Divisions");
        }
    }
}