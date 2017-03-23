using mvcsite.data;
using mvcsite.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace mvcsite.DAL
{
    public class UOW:  IUOW, IDisposable
    {

       
        private CRMContextDB _db = new CRMContextDB();
        private Repo<Contact> contactRepo;
        private Repo<Organization> orgRepo;
        private Repo<Note> noteRepo;
     



        public Repo<Contact> ContactRepo
        {
            get
            {
                if(this.contactRepo == null){
                    this.contactRepo = new Repo<Contact>(_db);
                }
                return contactRepo;
            }
        }

        public Repo<Organization> OrgRepo
        {
            get
            {
                if (this.orgRepo == null)
                {
                    this.orgRepo = new Repo<Organization>(_db);
                }
                return orgRepo;
            }
        }

        public Repo<Note> NoteRepo
        {
            get
            {
                if(this.noteRepo== null)
                {
                    this.noteRepo = new Repo<Note>(_db);
                }
                return noteRepo;
            }
        }
        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            if(_db != null)
            {
                _db.Dispose();
            }
        }
    }
}