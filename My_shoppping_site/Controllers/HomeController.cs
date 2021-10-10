using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_shoppping_site.Models;

namespace My_shoppping_site.Controllers
{
    
    public class HomeController : Controller
    {
        string a = "new commit push";
        Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult getlistview()
        {
            return View();
        }
          public string checkid(int id)
        {
            var list = new List<Student>()
            {
                new Student()
                {
                    Roll_No=2,
                    Name="Umer",
                    Age=22,
                    F_NAme="Ali"
                }, new Student()
                {
                    Roll_No=2,
                    Name="Umer",
                    Age=22,
                    F_NAme="Ali"
                }, new Student()
                {
                    Roll_No=2,
                    Name="Umer",
                    Age=22,
                    F_NAme="Ali"
                },
            };
           string s= Newtonsoft.Json.JsonConvert.SerializeObject(list);
            return s;
        }

        public ActionResult getlistfromview(string json)
        {

            var list = new List<Student>();
            List<Student> list1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Student>>(json);
            return RedirectToAction("getlistview");
        }

        public ActionResult product(int? id)
        {
            if (id != null)
            {
                TempData["catid"] = id;
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ADmin a)
        {
            int c = db.ADmins.Where(x => x.Admin_Email == a.Admin_Email && x.Admin_Password == a.Admin_Password).Count();
            if (c > 0) //if Record Find from admin Table
            {
                return RedirectToAction("Indexadmin");
            }
            else //if No Rcord Find From Admin table
            {
                ViewBag.msg = "Invalid Email And Password";
                return View();
            }

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult product_detail(int id)
        {
            Product p = db.Products.Find(id);
            ViewBag.pro = p;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult indexA()
        {
            return View();
        }
        public ActionResult indexadmin()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}