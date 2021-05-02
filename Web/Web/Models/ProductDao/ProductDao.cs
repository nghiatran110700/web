using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models.Entity;
using Web.Models.ProductDTO;
using PagedList
namespace Web.Models.ProductDao
{
    public class ProductDao
    {
        ShopModel db = new ShopModel();
       
        public IQueryable<Product> products
        {
            get { return db.Products; }
        }
        public IQueryable<Product> ListProduct()
        {
            var res = (from s in db.Products select s);
            return res;
        }
        public int InsertProduct(string name, decimal price, int amount, string description, string photo, int idcategory)
        {
            Product pro = new Product();
            pro.name = name;
            pro.pirce = price;
            pro.amount = amount;
            pro.description = description;
            pro.photo = photo;
            pro.idcategory = idcategory;
            db.Products.Add(pro);//luu tren RAM
            db.SaveChanges();//luu vao o dia
            return pro.id;
        }
        public void UpdateProduct(Product proTmp)
        {
            Product pro = db.Products.Find(proTmp.id);
            if (pro != null)
            {
                pro.name = proTmp.name;
                pro.pirce = proTmp.pirce;
                pro.amount = proTmp.amount;
                pro.description = proTmp.description;
                pro.photo = proTmp.photo;
                pro.idcategory = proTmp.idcategory;
                db.SaveChanges();
            }
        }
        public void DeleteProduct(int id)
        {
            Product pro = db.Products.Find(id);
            if (pro != null)
            {
                db.Products.Remove(pro);
                db.SaveChanges();
            }
        }
        public Product FindProductByID(int id)
        {
            return db.Products.Find(id);
        }
        public IEnumerable<ProductDTO> lstJoin(int pageNum, int pageSize)
        {
            var lst = db.Database.SqlQuery<ProductDTO>("SELECT " +
                " pro.id, " +
                " pro.name, " +
                " pro.price, " +
                " pro.amount, " +
                " pro.description, " +
                " pro.photo, " +
                " pro.idCategory, " +
                " c.name " +
                " FROM PRODUCT pro LEFT JOIN CATEGORY c on pro.IDCATEGORY = c.ID "
                ).ToPagedList<ProductDTO>(pageNum, pageSize);
            return lst;
        }
    }
}