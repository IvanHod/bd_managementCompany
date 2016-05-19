using System;
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
			Service ser = db.Services.Find(id);
			return View(ser);
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
			Service ser = db.Services.Find(id);
			return View (ser);
        }

        [HttpPost]
		public ActionResult Edit(int id, [Bind(Include = "name,description,price,period,isGeneral")]Service s)
        {
            try {
				db.Services.Find(id).editS(s);
				db.SaveChanges();
				return RedirectToAction("Index", "Organization");
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

		public JsonResult SelectAll() {
			List<Service> services = db.Services.ToList();
			return Json (services, JsonRequestBehavior.AllowGet);
		}

		public JsonResult Select(string ids)
		{
			List<Service> services = new List<Service> {};
			if (ids != null && ids != "" ) {
				string[] _ids = ids.Split(',');
				foreach(string id in _ids) {
					services.Add(db.Services.Find(Int16.Parse(id)));
				}
			}
			return Json (services, JsonRequestBehavior.AllowGet);
		}
    }
}