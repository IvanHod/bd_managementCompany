using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;

namespace manegementCompany.Controllers
{
    public class HouseController : Controller
	{
		private HouseContext db;

		public HouseController()
		{
			db = new HouseContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

        public ActionResult Details(int id)
        {
			House house = db.houses.Find (id);
            return View (house);
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
		public ActionResult Create([Bind (Include = "number,countFloor,countPorch,CountRoom,services")]MHouse h)
        {
			try {
				House house = new House(h);
				db.houses.Add(house);
				db.SaveChanges();
				string autoGeneration = Request.Params["autoGeneration"];
				string rooms = "";
				if( autoGeneration == "on" ) {
					int numberRoom = 1;
					List<Room> rms = new List<Room> {};
					for(int po = 0; po < h.countPorch; po++) {
						for(int fl = 0; fl < h.countFloor; fl++) {
							for(int ro = 0; ro < h.countRoom; ro++) {
								Room r = new Room(numberRoom, fl, ro+1);
								rms.Add(r);
								db.rooms.Add(r);
								numberRoom++;
							}
						}
					}
					db.SaveChanges();
					foreach(Room r in rms) {
						rooms += r.id + ",";
					}
					house.rooms = rooms;
					db.SaveChanges();
				}
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
			List<House> houses = db.houses.ToList ();
			return Json (houses, JsonRequestBehavior.AllowGet);
		}
    }
}