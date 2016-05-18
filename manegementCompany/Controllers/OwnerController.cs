using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;

namespace manegementCompany.Controllers
{
    public class OwnerController : Controller
    {
		private OwnerContext db;

		private HouseContext houseDb;

		public OwnerController()
		{
			db = new OwnerContext ();
			houseDb = new HouseContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Details(int id)
        {
			return View (new Owner(id));
        }

		public ActionResult Create(string id)
		{
			return View (new Owner(Int32.Parse(id)));
		} 

        [HttpPost]
		public ActionResult Create([Bind (Include = "name,lastName,patronimic,phone,email,room")]Owner o)
        {
            try {
				db.owners.Add(o);
				db.SaveChanges();
				houseDb.rooms.Find(o.room).owner = o.id;
				houseDb.SaveChanges();
				return RedirectToAction ("Details/"+o.room, "Room");
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
    }
}