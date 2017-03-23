using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvcsite.Models;
using mvcsite.data;
using mvcsite.ViewModels;
using AutoMapper;
using System.Linq.Expressions;
using mvcsite.DAL;

namespace mvcsite.Controllers
{
    public class ContactsController: Controller 
    {

        private UOW unitOfWork = new UOW();
      
        

        public ContactsController()
        {
          
        }


        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetContacts(string name="",string email="", string id = "")
        {
            //var rep = unitOfWork.GetRepository<IRepo<Contact>>();
            
            var pb = PredicateBuilder.True<Contact>();

            if (!string.IsNullOrEmpty(name))
            {
                pb = pb.And(c => c.FirstName.ToLower().StartsWith(name) || c.LastName.ToLower().StartsWith(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                pb = pb.And(c => c.EMail.ToLower().Contains(email));
            }
            //let's work on how best to crate expression

            Expression<Func<Contact, bool>> Expr = pb;
           


            return PartialView("ListContacts", unitOfWork.ContactRepo.Find(Expr).ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = unitOfWork.ContactRepo.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            var vm = new ContactViewModel();
            vm.OrganizationSelectListItems = unitOfWork.OrgRepo.GetAll().Select(i => new SelectListItem()
                                                                {
                                                                    Text = i.Name.ToString(),
                                                                    Value = i.Id.ToString()
                                                                });

            return PartialView(vm);
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ContactViewModel cvm)
        {
            var contact = new Contact();
            contact.FirstName = cvm.FirstName;
            contact.LastName = cvm.LastName;
            contact.EMail = cvm.EMail;
            contact.PhoneNumber = cvm.PhoneNumber;
            contact.OrgID = cvm.OrgId;
            if (ModelState.IsValid)
            {
                unitOfWork.ContactRepo.Add(contact);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = unitOfWork.ContactRepo.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            var vm = new ContactViewModel();
            vm = AutoMapper.Mapper.Map<Contact, ContactViewModel>(contact);
            vm.OrganizationSelectListItems = unitOfWork.OrgRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name.ToString(),
                Value = i.Id.ToString()
            });
            
            
            return View(vm);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactViewModel vm)
        {
            var contact = new Contact();
                contact = Mapper.Map<ContactViewModel, Contact>(vm);
            if (ModelState.IsValid)
            {
            
                unitOfWork.ContactRepo.Update(contact);
                unitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = unitOfWork.ContactRepo.GetById(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = unitOfWork.ContactRepo.GetById(id);
            unitOfWork.ContactRepo.Delete(id);
            unitOfWork.Commit();
            return RedirectToAction("Index");
        }

        
    }
}
