using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class UsersVM
    {
        public IEnumerable<Users> UserList { get; set; }
        public Users Users { get; set; }
    }
}
