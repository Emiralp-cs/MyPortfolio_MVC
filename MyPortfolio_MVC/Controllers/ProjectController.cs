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
        MyPortfolioEntities db1 = new MyPortfolioEntities();

        private void CategoryDropDown()
        {
            var categorylist = db1.TblCategories.ToList();

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
            var projects = db1.TblProjects.ToList();
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
            db1.TblProjects.Add(model);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db1.TblProjects.Find(id);
            db1.TblProjects.Remove(value);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]//Index sayfasındayken proje güncelle butonuna basıldığında yüklenecek bilgiler 
        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value = db1.TblProjects.Find(id);
            return View(value); 
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropDown();

            var value = db1.TblProjects.Find(model.ProjectId);
            value.Name = model.Name;
            value.GithubUrl = model.GithubUrl;
            value.Description = model.Description;
            value.CategoryId = model.CategoryId;
            value.ImageUrl = model.ImageUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db1.SaveChanges();
            return RedirectToAction("Index");


        } 
    }
}