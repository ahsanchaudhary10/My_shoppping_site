using My_shoppping_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_shoppping_site.Controllers
{
    public class CartController : Controller
    {
        Model1 db = new Model1();
        // GET: Cart
        public ActionResult displaycart()
        {
            return View();
        }
         public ActionResult Addtocart(int id)
        {
            List<Product> customerlist = new List<Product>();
            if (Session["customercart"] != null)
            {
                customerlist = (List<Product>)Session["customercart"];
            }
           Product p= db.Products.Find(id);
            customerlist.Add(p);
            Session["customercart"] = customerlist;
            return RedirectToAction("displaycart");
        }
        public ActionResult Removerfromcart(int id)
        {
            int index = id;
            List<Product> list = (List<Product>)Session["customercart"];
            list.RemoveAt(index);
            Session["customercart"] = list;
            return RedirectToAction("displaycart");
        }

    }
}