using System.Collections.Generic;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class UsersVM
    {
        public IEnumerable<Offices> OfficesList { get; set; }

        public IEnumerable<Divisions> DivisionsList { get; set; }
        public Users Users { get; set; }
    }
}
