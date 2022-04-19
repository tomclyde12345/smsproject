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
            var users = _context.Users.Include(u => u.Offices).ToList(); 
            return View(users);
        }

        public ActionResult New()
        {
            var offices = _context.Offices.ToList();
            var vm = new UsersVM()
            {
                OfficesList = offices
            };
            return View("Create", vm);
        }
        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);
            if (user == null)
                return HttpNotFound();
            return View("Edit", user);
        }

        public ActionResult Save(Users users)

        {
            if (users.Id == 0)
            {
                users.DateAdded = DateTime.Now;
                _context.Users.Add(users);

                
            }
            else
            {
                var usersInDb = _context.Users.Single(c => c.Id == users.Id);

                usersInDb.Name = users.Name;
                usersInDb.Address = users.Address;
                usersInDb.DateAdded = DateTime.Now;
                usersInDb.EmailAddress = users.EmailAddress;
                usersInDb.age = users.age;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");

        }
        //  [HttpPost]
        // // public ActionResult Save(Users sUsers)

        //      if (sUsers.Id == 0)
        //      _context.Users.Add(users);
        //  else
        //  {
        //  var usersInDb = _context.Users.Single(c => c.Id == users.Id);
        //
        //    usersInDb.Name = users.Name;
        //   usersInDb.Address = users.Address;
        //   usersInDb.DateAdded = users.DateAdded;
        //   usersInDb.EmailAddress = users.EmailAddress;
        //  usersInDb.age = users.age;




    }

}

