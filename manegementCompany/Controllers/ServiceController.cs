﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.ContextDbs;
using web.Models;

namespace manegementCompany.Controllers
{
    public class ServiceController : Controller
	{
		private ServiceContext db;

		public ServiceController()
		{
			db = new ServiceContext ();
		}

		public JsonResult Index()
		{
			List<Service> services = db.Services.ToList ();
			return Json (services, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create([Bind (Include = "name,description,price,period,isGeneral")]Service s)
        {
            try {
				db.Services.Add(s);
				db.SaveChanges();
                return RedirectToAction ("Index", "Organization");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

        public ActionResult Delete(int id)
        {
            return View ();
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
            } catch {
                return View ();
            }
        }

		public JsonResult Select()
		{
			List<Service> services = db.Services.ToList ();
			return Json (services, JsonRequestBehavior.AllowGet);
		}
    }
}