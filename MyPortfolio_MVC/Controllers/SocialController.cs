using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class SocialController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {   
            var value = db.TblSocialMedias.ToList();
            return View(value);
        }


        public ActionResult Delete(int id) 
        {
            var value = db.TblSocialMedias.Find(id);
            db.TblSocialMedias.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TblSocialMedia model)
        {
            db.TblSocialMedias.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Update(int id) 
        {
            var value = db.TblSocialMedias.Find(id);
            return View(value);
        }

         
        [HttpPost]
        public ActionResult Update(TblSocialMedia model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = db.TblSocialMedias.Find(model.SocialMediaId);
            value.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult BannerSocialMedia()
        {
            var value = db.TblSocialMedias.ToList();
            return PartialView(value);
        }
    }
}