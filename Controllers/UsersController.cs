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
        
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        // GET: Users
        public ActionResult Index()
        {
            var userModel = _context.UsersModel.ToList();
            return View(userModel);
        }

        public ActionResult New()
        {
            var userList = _context.UsersModel.ToList();
            var viewModel = new RandomMovieViewModel()
            {
                UserList = userList
            };
            return View("UsersView", viewModel);
        }

        public ActionResult Save(UsersModel customerModel)
        {
            if (customerModel.Id == 0)
            {
                customerModel.DateAdded = DateTime.Now;
                _context.UsersModel.Add(customerModel);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}
