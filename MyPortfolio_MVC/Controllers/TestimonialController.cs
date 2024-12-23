using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblTestimonials.ToList();
            return View(value);
        }


       

        public ActionResult Delete(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]

        public ActionResult Add(TblTestimonial model)
        {
            db.TblTestimonials.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.TblTestimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Update(TblTestimonial model)
        {
            var value = db.TblTestimonials.Find(model.TestimonialId);
            value.ImageUrl = model.ImageUrl;
            value.Title = model.Title;
            value.NameSurname = model.NameSurname;
            value.Comment = model.Comment;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}