using mvcsite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcsite.data
{
    public class CRMContextDB : DbContext
    {
        public CRMContextDB(): base(ConfigurationManager.ConnectionStrings["CRMConncetionString"].ConnectionString)
        {

        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Note> Notes { get; set; }
    }
}