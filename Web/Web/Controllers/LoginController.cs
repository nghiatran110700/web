using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.Entity;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ShopModel db = new ShopModel();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account acc)
        {
            foreach(var item in db.Accounts)
            {
                if (acc.username.Equals(item.username) && acc.password.Equals(item.password))
                {
                    Session["username"] = item.fullname;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}