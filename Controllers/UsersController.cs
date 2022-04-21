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
            var users = _context.Users
                .Include(u => u.Offices)
                .Include(u=>u.Divisions)
                .ToList(); 
            return View(users);
        }

        public ActionResult New()
        {
            var offices = _context.Offices.ToList();
            var divs = _context.Divisions.ToList();
            var vm = new UsersVM()
            {
                DivisionsList = divs,
                OfficesList = offices
            };
            return View("Create", vm);
        }
        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id);

            var vm = new UsersVM()
            {
                Users = user,
                OfficesList = _context.Offices.ToList(),
                DivisionsList = _context.Divisions.ToList()
            };
            if (user == null)
                return HttpNotFound();

            return View("Edit", vm);
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
                usersInDb.OfficesId = users.OfficesId;
                usersInDb.DivisionsId = users.DivisionsId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Users");

        } 
    }

}

