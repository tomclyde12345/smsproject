using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class OfficeVM
    {
        public IEnumerable<Offices> OfficesList { get; set; }
        public Offices Offices { get; set; }
    }
}