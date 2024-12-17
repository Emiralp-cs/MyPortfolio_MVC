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
    }


}