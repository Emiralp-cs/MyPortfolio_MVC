using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ExperienceController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {   
            var value = db.TblExperiences.ToList();

            return View(value);
        }

        public ActionResult DeleteExperience(int id)
        {
            var silinecekdeger = db.TblExperiences.Find(id);//
            db.TblExperiences.Remove(silinecekdeger);
            db.SaveChanges();//bu metot işlemleri kaydeder ve database de kaç tane satırın etkilendiğini döner.
            return RedirectToAction("Index");
        }
        [HttpGet]//View i yükle
        public ActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]//View de yapılan işlemleri kaydet
        public ActionResult CreateExperience(TblExperience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }
            db.TblExperiences.Add(experience);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var value = db.TblExperiences.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperience model)
        {
            var value = db.TblExperiences.Find(model.ExperienceId);
            value.StartDate = model.StartDate;
            value.EndDate = model.EndDate;
            value.CompanyName = model.CompanyName;
            value.Title = model.Title;
            value.Description = model.Description;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}