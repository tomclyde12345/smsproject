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
        
        private ApplicationDbContext _context;  //ACCESS TO DATABASE

        public UsersController()
        {
            _context = new ApplicationDbContext();  //ACCESS TO DATABASE
        }

        protected override void Dispose(bool disposing) //TIGIL LOOP
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
            var offices = _context.Offices.ToList(); //CREATE
            var vm = new UsersVM()
            {
                OfficesList = offices
            };
            return View("Create", vm);
        }
        public ActionResult Edit(int id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Id == id); //EDIT METHOD
            if (user == null)
                return HttpNotFound();
            var viewModel = new UsersVM()
            {
                Users = user,
                OfficesList = _context.Offices.ToList()
            };

            return View("Edit", viewModel);
        }

        public ActionResult Save(Users users)       //SAVE METHOD 

        {
            if (users.Id == 0)                          
            {
                users.DateAdded = DateTime.Now;
                _context.Users.Add(users);
            }
            else
            {
                var usersInDb = _context.Users.Single(c => c.Id == users.Id);   //SAVE METHOD AFTER EDITING

                usersInDb.Name = users.Name;
                usersInDb.Address = users.Address;
                usersInDb.DateAdded = DateTime.Now;
                usersInDb.EmailAddress = users.EmailAddress;
                usersInDb.OfficesId = users.OfficesId;
                usersInDb.age = users.age;
            }
            _context.SaveChanges();                       
            return RedirectToAction("Index", "Users");

        }
        
    }

}

