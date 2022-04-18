using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class RandomMovieViewModel
    {
        public UsersModel UsersModel { get; set; }
        public List<Customer> Customers { get; set; }
    }
}