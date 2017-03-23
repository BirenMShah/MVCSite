using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcsite.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated{ get; set; }
        public DateTime DateLastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public int? ContactId { get; set; }
        public int? OrganizationId { get; set; }

        [ForeignKey("ContactId")]
        public virtual Contact Contact { get; set; }
        [ForeignKey("OrganizationId")]
        public virtual Organization Orgnaization { get; set; }



    }
}