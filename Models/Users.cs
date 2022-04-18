using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smsproject.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DateAdded { get; set; }
        public int age { get; set; }
        public string EmailAddress { get; set; }  
    }
}
