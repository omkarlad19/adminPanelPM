﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using adminPanelPM.Models;

namespace adminPanelPM.Controllers
{
    public class ProfileController : Controller
    {
        KahreedoEntities1 db = new KahreedoEntities1();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.admin_Employee.Find(TemData.EmpID));

        }

        public ActionResult Edit(int id)
        {
          admin_Employee emp=  db.admin_Employee.Find(id);
          if (emp==null)
          {
              return HttpNotFound();
          }
           return View(emp);
        }

        [HttpPost]
        public ActionResult Edit(admin_Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}