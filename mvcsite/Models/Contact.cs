using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcsite.Models
{
    public class Contact
    {

       
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }

       
        public int OrgID { get; set; }
        [ForeignKey("OrgID")]
        public virtual Organization Organization { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}