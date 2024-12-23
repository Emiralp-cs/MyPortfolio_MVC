using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ExpertiseController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblExpertises.ToList();
            return View(value);
        }

        public ActionResult ExpertiseDelete(int id)
        {
            var value = db.TblExpertises.Find(id);
            db.TblExpertises.Remove(value);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var value = db.TblExpertises.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult Update(TblExpertis model)
        {
            var value = db.TblExpertises.Find(model.ExpertiseId);

            value.Title = model.Title;
            value.Description = model.Description;
            value.BarHeight = model.BarHeight;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ExpertiseCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ExpertiseCreate(TblExpertis model)
        {
            db.TblExpertises.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}