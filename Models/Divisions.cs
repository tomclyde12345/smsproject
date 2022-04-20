using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace smsproject.Models
{
    public class Divisions
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Offices Offices { get; set; }
        public int OfficesId { get; set; }
    }
}