using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace smsproject.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime? DateAdded { get; set; }
        public int age { get; set; }
        public string EmailAddress { get; set; }

        public Offices Offices { get; set; }
        public int OfficesId { get; set; } 


        public Divisions Divisions { get; set; }

        public int DivisionsId { get; set; }
    }
}
