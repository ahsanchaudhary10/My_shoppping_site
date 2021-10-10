using My_shoppping_site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        public ActionResult Order_Book()
        {
            return View();
        }
        public ActionResult checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult checkout(Order o)
        {
            o.Order_Type = "Sale";
            o.Order_Status = "Pending";
            o.Order_Datetime = System.DateTime.Now;
            db.Orders.Add(o);
            db.SaveChanges();
            List<Product> list = (List<Product>)Session["customercart"];
            foreach (var item in list)
            {
                Order_Detail od=new Order_Detail();
                od.product_fid = item.Product_id;
                od.purchase_price = item.Product_Purchase_Price;
                od.Sale_price = item.Product_Price;
                od.quantity = item.quantity;
                od.Orde_fid = o.Order_id;
                db.Order_Detail.Add(od);
                db.SaveChanges();

            }
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("baig021389@gmail.com");
            mail.To.Add(o.Person_Email);
            mail.Subject = "Order Confirmation";
            mail.Body = " <h2> Hi "+o.Person_Name+" </h2> <br/>  your order hase been booked and order number is "+o.Order_id+" Thanks For shopping here ";
            mail.IsBodyHtml = true;

            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("baig021389@gmail.com", "baig 328873");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            TempData["persondeatil"] = o;
            TempData["orderdetail"] = Session["customercart"];
            Session["customercart"] = null;
            return RedirectToAction("Order_Book");
        }
         public ActionResult Addtocart(int id)
        {
            List<Product> customerlist = new List<Product>();
            if (Session["customercart"] != null)
            {
                customerlist = (List<Product>)Session["customercart"];
            }
            Product product = customerlist.Where(x => x.Product_id == id).FirstOrDefault();
            if (product != null)
            {
                product.quantity++;
            }
            else
            {
                Product p = db.Products.Find(id);
                p.quantity = 1;
                customerlist.Add(p);
            }
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
        public ActionResult minuscart(int id)
        {
            List<Product> list = (List<Product>)Session["customercart"];
           
            list[id].quantity--;
            if (list[id].quantity < 1)
            {
                list.RemoveAt(id);
            }
            Session["customercart"] = list;
            return RedirectToAction("displaycart");
        }
        public ActionResult pluscart(int id)
        {
            List<Product> list = (List<Product>)Session["customercart"];
            list[id].quantity++;
            Session["customercart"] = list;
            return RedirectToAction("displaycart");
        }


    }
}