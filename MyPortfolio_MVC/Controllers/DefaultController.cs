using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        MyPortfolioEntities db1 = new MyPortfolioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultBanner()
        {
            var values = db1.TblBanners.Where(x => x.IsShown == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExpertise()
        {
            var values = db1.TblExpertises.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExperience()
        {
            var values = db1.TblExperiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = db1.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEducation()
        {
            var values = db1.TblEducations.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjects()
        {
            var values = db1.TblProjects.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {   
            var value = db1.TblSocialMedias.ToList();
            return PartialView(value);
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage model)
        {
            model.IsRead = false;
            db1.TblMessages.Add(model);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        

        public PartialViewResult DefaultTestimonials()
        {
            var value = db1.TblTestimonials.ToList();
            return PartialView(value);
        }

        
    }
}