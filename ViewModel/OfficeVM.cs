using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class OfficeVM
    {
        public IEnumerable<Offices> OfficeList { get; set; }
        public Offices Offices{ get; set; }
    }
}