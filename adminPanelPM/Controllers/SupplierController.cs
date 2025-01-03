﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using adminPanelPM.Models;

namespace adminPanelPM.Controllers
{
    public class SupplierController : Controller
    {

        KahreedoEntities1 db = new KahreedoEntities1();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(adminPanelPM.Models.Supplier supp)
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(supp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            adminPanelPM.Models.Supplier supp = db.Suppliers.Single(x => x.SupplierID == id);
            if (supp==null)
            {
                return HttpNotFound();
            }
            return View(supp);
        }

        [HttpPost]
        public ActionResult Edit(adminPanelPM.Models.Supplier supp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supp);
        }

        public ActionResult Details(int id)
        {
            adminPanelPM.Models.Supplier supp = db.Suppliers.Find(id);
            if (supp == null)
            {
                return HttpNotFound();
            }
            return View(supp);
        }

        public ActionResult Delete(int id)
        {
            adminPanelPM.Models.Supplier supp = db.Suppliers.Find(id);
            if (supp == null)
            {
                return HttpNotFound();
            }
            return View(supp);
        }

        //Post Delete Confirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            adminPanelPM.Models.Supplier supp = db.Suppliers.Find(id);
            db.Suppliers.Remove(supp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}