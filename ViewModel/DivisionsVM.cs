using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class DivisionsVM
    {
        public IEnumerable<Offices> OfficesList { get; set; }
        public Divisions Divisions { get; set; }
    }
}