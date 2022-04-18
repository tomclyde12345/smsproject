using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smsproject.Models;

namespace smsproject.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            var userModel = _context.UsersM.ToList();
            return View(userModel);
        }
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var userList = _context.UsersM.ToList();
            var awit = new UsersModel()
            {
                UserList = userList
            };
            return View("UsersView", awit);
        }

        public ActionResult Save(UsersModel customerModel)
        {
            if (customerModel.Id == 0)
            {
                customerModel.DateAdded = DateTime.Now;
                _context.UsersM.Add(customerModel);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}
