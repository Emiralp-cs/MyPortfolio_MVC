using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    //Web configde yaptığımız işlemi burada tanımlayıp güvence altına alıyoruz.
    public class CategoryController : Controller
    {
        MyPortfolioEntities db1 = new MyPortfolioEntities();

        public ActionResult Index()


        {
            var values = db1.TblCategories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(TblCategory category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            db1.TblCategories.Add(category);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = db1.TblCategories.Find(id);

            var projectExist = db1.TblProjects.Where(x => x.CategoryId == value.CategoryId).Any();
            if (projectExist)
            {
                TempData["categoryDeleteError"] = "Bu kategoriye ait proje bulunmaktadır. Bu Kategoriyi Silemezsiniz.";
                return RedirectToAction("Index");
            }

            db1.TblCategories.Remove(value);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db1.TblCategories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(TblCategory model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var value = db1.TblCategories.Find(model.CategoryId);
            value.Name = model.Name;
            db1.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}