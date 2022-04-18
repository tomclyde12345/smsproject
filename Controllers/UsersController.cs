using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using smsproject.Models;
using smsproject.ViewModel;

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
            var users = _context.Users.ToList();

            
            return View(users);
        }

        public ActionResult New()
        {
            var users = _context.Users.ToList();
            var vm = new UsersVM()
            {
                UserList = users
            };
            return View("Create", vm);
        }

        public ActionResult Save(Users users)
        {
            if (users.Id == 0)
            {
                users.DateAdded = DateTime.Now;
                _context.Users.Add(users);
                
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Users");
        }
    }
}
