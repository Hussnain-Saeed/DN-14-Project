using ShoppingApplication.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingApplication.WebUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //Ctrl + SHift + B= Rebuilding Project
        ShoppingContext db = new ShoppingContext();
        public ActionResult Index()
        {
            List<Product> model = db.Products.ToList();
            return View(model);
        }
        public ActionResult Delete(int Id)
        {
            Product product = db.Products.Find(Id);
            db.Products.Remove(product);
            db.SaveChanges();
            return Redirect("/Product/Index");
        }
        public ActionResult View(int Id)
        {
            Product product = db.Products.Find(Id);
            return View(product);
        }
    }
}