using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        private void CategoryDropDown()
        {
            var categorylist = db.TblCategories.ToList();

            List<SelectListItem> Categories = (from x in categorylist
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString(),
                                               }).ToList();
            ViewBag.Categories = Categories;
        }

        public ActionResult Index()
        {
            var projects = db.TblProjects.ToList();
            return View(projects);
        }



        [HttpGet] 
        public ActionResult CreateProject()
        {
            CategoryDropDown();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject model)
        {
            CategoryDropDown();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]//Index sayfasındayken proje güncelle butonuna basıldığında yüklenecek bilgiler 
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value = db.TblProjects.Find(id);
            return View(value); 
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropDown();

            var value = db.TblProjects.Find(model.ProjectId);
            value.Name = model.Name;
            value.GithubUrl = model.GithubUrl;
            value.Description = model.Description;
            value.CategoryId = model.CategoryId;
            value.ImageUrl = model.ImageUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.SaveChanges();
            return RedirectToAction("Index");


        } 
    }
}