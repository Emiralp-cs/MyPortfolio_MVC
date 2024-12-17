using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyPortfolio_MVC.Controllers
{

    public class EducationController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var educations = db.TblEducations.ToList();
            return View(educations);
        }


        public ActionResult DeleteEducation(int id)
        {
            var silinecekdeger = db.TblEducations.Find(id);//
            db.TblEducations.Remove(silinecekdeger);
            db.SaveChanges();//bu metot işlemleri kaydeder ve database de kaç tane satırın etkilendiğini döner.
            return RedirectToAction("Index");
        }


        [HttpGet]//View i yükle
        public ActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]//View de yapılan işlemleri kaydet
        public ActionResult CreateEducation(TblEducation education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }
            db.TblEducations.Add(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = db.TblEducations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(TblEducation model)
        {
            var value = db.TblEducations.Find(model.EducationId);
            value.EducationId = model.EducationId;
            value.StartDate = model.StartDate;
            value.EndDate = model.EndDate;
            value.SchoolName = model.SchoolName;
            value.Department = model.Department;
            value.Description = model.Description;
            value.Degree = model.Degree;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }


}