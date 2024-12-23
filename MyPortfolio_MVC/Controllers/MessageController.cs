using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioEntities db1 = new MyPortfolioEntities();
        public ActionResult Index()
        {
            var values = db1.TblMessages.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult MessageDetail(int? id)
        {

            var value = db1.TblMessages.Find(id);

            return View(value);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = db1.TblMessages.Find(id);
            db1.TblMessages.Remove(value);
            db1.SaveChanges();
            return RedirectToAction("Index");
        }




        public ActionResult MakeMessageUnRead(int? id)
        {
            var value = db1.TblMessages.Find(id);
            value.IsRead = false;
            db1.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakeMessageRead(int? id)
        {
            var value = db1.TblMessages.Find(id);
            value.IsRead = true;
            db1.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult DropDownMessage()
        {
            var value = db1.TblMessages.Where(x => x.IsRead == false).ToList();

            return PartialView(value);
        }


    }
}