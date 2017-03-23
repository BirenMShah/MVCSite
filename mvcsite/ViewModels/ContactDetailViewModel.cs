using mvcsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcsite.ViewModels
{
    public class ContactDetailViewModel
    {
        public Contact Contact;

        public List<Note> Notes { get; set; }
    }
}