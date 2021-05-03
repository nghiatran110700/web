using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models.ProductDao;
using Web.Models.Entity;
using PagedList.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int pageNum =1, int pageSize =2)
        {
            ProductDao dao = new ProductDao();
            return View(dao.lstJoin(pageNum,pageSize));
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}