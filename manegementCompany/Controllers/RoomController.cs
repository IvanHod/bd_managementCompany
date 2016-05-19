using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;

namespace manegementCompany.Controllers
{
    public class RoomController : Controller
    {
		private HouseContext db;

		public RoomController()
		{
			db = new HouseContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Details(int id)
        {
			return View (db.rooms.Find(id));
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try {
                return RedirectToAction ("Index");
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
			string roomsStr = Request.Params ["rooms"];
			string[] rooms = roomsStr.Split (',');
			List<Room> rms = new List<Room> {};
			foreach(string id in rooms) {
				int _id = Int32.Parse (id);
				rms.Add(db.rooms.Find(_id));
			}
			return Json (rms, JsonRequestBehavior.AllowGet);
		}
    }
}