using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsproject.Models;

namespace smsproject.ViewModel
{
    public class DivisionVM
    {
        public IEnumerable<Division> DivisionList { get; set; }
        public Division Divisions { get; set; }
    }
}