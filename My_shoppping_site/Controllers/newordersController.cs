using My_shoppping_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_shoppping_site.Controllers
{
    public class newordersController : Controller
    {
        Model1 db = new Model1();
        // GET: neworders
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult updatestatus(int id)
        {
            Order order = db.Orders.Where(x => x.Order_id == id).FirstOrDefault();
            order.Order_Status = "Deliver";
            db.Entry(order).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            //TempData["confirm"] = "Order no "++"  Updated";
            return RedirectToAction("Index");
        }
    }
}