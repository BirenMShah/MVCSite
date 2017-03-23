using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcsite.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public  virtual List<Contact> Contacts { get; set; }

        public virtual List<Note> Notes { get; set; }


    }
}