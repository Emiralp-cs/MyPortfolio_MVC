using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ContactsController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblContacts.ToList();


            return View(value);
        }


        public PartialViewResult Contact()
        {
            var value = db.TblContacts.ToList();

            return PartialView(value);
        }

        public ActionResult Delete(int id) 
        {
            var value = db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index","Contacts");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult Add(TblContact model) 
        {
            db.TblContacts.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Contacts");


        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.TblContacts.Find(id);

            return View(value);
        }

        [HttpPost]
        public ActionResult Update(TblContact model) 
        {
            var value = db.TblContacts.Find(model.ContactId);
            value.Email = model.Email;
            value.Phone = model.Phone;
            db.SaveChanges();
            return RedirectToAction("Index", "Contacts");

        }


    }
}