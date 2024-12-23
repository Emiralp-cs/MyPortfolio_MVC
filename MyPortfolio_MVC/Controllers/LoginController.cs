using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio_MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyPortfolioEntities db1 = new MyPortfolioEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            var value = db1.TblAdmins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            //where kullanmamamızın sebebi birden fazla değer döndürebilecek olması 
            //FirsOrDefault kullanmamızın sebebi ise eğerki bir değer bulamazsa hata fırlatmak yerine onun ilk değer tipini döner
           

            if (value == null) 
            {
                ModelState.AddModelError("", "Email veya Şifre Hatalı");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(value.Email, false);

            Session["email"] = value.Email;
            return RedirectToAction("Index","Category");
        }

    }
}