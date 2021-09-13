using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using My_shoppping_site.Models;

namespace My_shoppping_site.Controllers
{
    public class ADminsController : Controller
    {
        Model1 db = new Model1();

        // GET: ADmins
        public ActionResult Index()
        {
            return View(db.ADmins.ToList());
        }

        // GET: ADmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADmin aDmin = db.ADmins.Find(id);
            if (aDmin == null)
            {
                return HttpNotFound();
            }
            return View(aDmin);
        }

        // GET: ADmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADmins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Admin_id,Admin_Name,Admin_Password,Admin_Gender,Admin_Phone,Admin_Address")] ADmin aDmin)
        {
            if (ModelState.IsValid)
            {
                db.ADmins.Add(aDmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDmin);
        }

        // GET: ADmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADmin aDmin = db.ADmins.Find(id);
            if (aDmin == null)
            {
                return HttpNotFound();
            }
            return View(aDmin);
        }

        // POST: ADmins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Admin_id,Admin_Name,Admin_Password,Admin_Gender,Admin_Phone,Admin_Address")] ADmin aDmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDmin);
        }

        // GET: ADmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADmin aDmin = db.ADmins.Find(id);
            if (aDmin == null)
            {
                return HttpNotFound();
            }
            return View(aDmin);
        }

        // POST: ADmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADmin aDmin = db.ADmins.Find(id);
            db.ADmins.Remove(aDmin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
