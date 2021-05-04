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
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            ProductDao dao = new ProductDao();
            int t = dao.InsertProduct(pro.name, Convert.ToDecimal(pro.pirce), Convert.ToInt32(pro.amount), pro.description, pro.photo, Convert.ToInt32(pro.idcategory));
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            ProductDao dao = new ProductDao();
            Product pro = new Product();
            pro = dao.FindProductByID(id);
            return View(pro);

        }
        [HttpPost]
        public ActionResult Edit(Product pro)
        {
            ProductDao dao = new ProductDao();
            dao.UpdateProduct(pro);
            return RedirectToAction("Index");
        }
        public ActionResult Detail(int id)
        {
            ProductDao dao = new ProductDao();
            Product pro = new Product();
            pro = dao.FindProductByID(id);
            return View(pro);
        }
        public ActionResult Delete(int id)
        {
            ProductDao dao = new ProductDao();
            Product pro = new Product();
            pro = dao.FindProductByID(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Delete(Product pro)
        {
            ProductDao dao = new ProductDao();
            dao.DeleteProduct(pro.id);
            return RedirectToAction("Index");
        }
    }
}