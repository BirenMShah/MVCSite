using mvcsite.DAL;
using mvcsite.data;
using mvcsite.Models;
using mvcsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcsite.Controllers
{
    public class NotesController : Controller
    {
        private UOW uow = new UOW();
        
        // GET: Notes
        public ActionResult Index()
        {
            return View(uow.NoteRepo.GetAll());
        }

        public ActionResult OrgNotes(int OrganizationId)
        {
            return View(uow.NoteRepo.GetAll().Where(n=>n.OrganizationId==OrganizationId));
        }

        public ActionResult ContactNotes(int ContactId)
        {
            return View(uow.NoteRepo.GetAll().Where(n => n.ContactId == ContactId));
        }

        public ActionResult Create(string notetype, int SrcId)
        {
            NoteViewModel nvm = new NoteViewModel();
            NoteType nType = (NoteType)Enum.Parse(
                                          typeof(NoteType), notetype, true);
            nvm.NoteType = nType;
            nvm.SrcId = SrcId;
            return PartialView(nvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteViewModel nvm)
        {
            var Note = new Note();
            
            Note = AutoMapper.Mapper.Map<NoteViewModel, Note>(nvm);
            if (ModelState.IsValid)
            {
                if (nvm.NoteType == NoteType.Contact)
                {
                    Note.ContactId = nvm.SrcId;
                }
                else
                {
                    Note.OrganizationId = nvm.SrcId;
                }
                Note.DateCreated = DateTime.Now;
                Note.DateLastUpdated = DateTime.Now;
                Note.CreatedBy = "biren";
                Note.UpdatedBy = "biren";
                uow.NoteRepo.Add(Note);
                uow.Commit();

                if (nvm.NoteType == NoteType.Contact)
                {
                    return RedirectToAction("Details", "Contacts", new { id = nvm.SrcId });
                }
                else
                {
                    return RedirectToAction("Details", "Organizations", new { id = nvm.SrcId });
                }
                   
            }

            return View(nvm);
        }
    }
}