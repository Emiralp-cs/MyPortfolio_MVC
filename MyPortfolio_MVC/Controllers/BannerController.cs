using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblBanners.ToList();
            return View(value);
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            db.TblBanners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateBanner(TblBanner model)
        {
            var value = db.TblBanners.Find(model.BannerId);
            value.Description = model.Description;
            value.Title = model.Title;
            value.IsShown = model.IsShown;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddBanner()
        {
            return View();

        }



        [HttpPost]
        public ActionResult AddBanner(TblBanner model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            db.TblBanners.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Shown(int id)
        {
            var value = db.TblBanners.Find(id);
            value.IsShown = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UnShown(int id)
        {
            var value = db.TblBanners.Find(id);
            value.IsShown = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}