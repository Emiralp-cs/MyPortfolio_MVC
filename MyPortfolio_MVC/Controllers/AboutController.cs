using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var value = db.TblAbouts.ToList();
            return View(value);
        }


        [HttpGet]
        public ActionResult AboutUpdate(int id)
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult AboutUpdate(TblAbout model)
        {
            var value = db.TblAbouts.Find(model.AboutId);


            if (model.ImageFile != null)
            {
                var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var saveLocation = currentDirectory + "images\\";
                var filename = Path.Combine(saveLocation, model.ImageFile.FileName);
                model.ImageFile.SaveAs(filename);
                model.ImageUrl = "/images/" + model.ImageFile.FileName;


            }

            if (model.CvFile != null)
            {
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "cv\\";
                    var cvFileName = Path.Combine(cvSaveLocation, model.CvFile.FileName);
                    model.CvFile.SaveAs(cvFileName);
                    model.CvUrl = "/cv/" + model.CvFile.FileName;
                }
                value.ImageUrl = model.ImageUrl;
                value.Title = model.Title;
                value.Description = model.Description;
                value.ImageUrl = model.ImageUrl;
                value.CvUrl = model.CvUrl;
                db.SaveChanges();
                



            }
            return RedirectToAction("Index");
        }
    }
}