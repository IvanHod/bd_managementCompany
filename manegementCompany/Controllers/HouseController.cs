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
		private OwnerContext ownerDb;

		public HouseController()
		{
			db = new HouseContext ();
			ownerDb = new OwnerContext ();
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
			AuthModel model = (AuthModel)Session ["Model"];
			if (model != null)
				return View ();
			else
				return RedirectToAction ("Index", "Home");
        } 

        [HttpPost]
		public ActionResult Create(
			[Bind (Include = "number,countFloor,countPorch,CountRoom,region,city,street,services")]MHouse h)
        {
			try {
				h.organization = ((AuthModel)Session["Model"]).getId();
				Address address = new Address ( h.region, "", h.city, h.street, h.number).save();
				House house = new House(h, address.id);
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
			House house = db.houses.Find(id);
			string[] roomsId = house.rooms.Split(',');
			foreach (string idRoom in roomsId)
			{
				if (idRoom != "" && idRoom != " ") {
					Room room = db.rooms.Find(Int16.Parse(idRoom));
					if (room != null)
					{
						if (room.owner > 0)
						{
							Owner owner = ownerDb.owners.Find(room.owner);
							ownerDb.owners.Remove(owner);
							ownerDb.SaveChanges();
						}
						db.rooms.Remove(room);
						db.SaveChanges();
					}
				}
			}
			db.houses.Remove(house);
			db.SaveChanges();
			return RedirectToAction("Index", "Organization");
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
			int id = ((AuthModel)Session ["Model"]).getId ();
			List<House> houses = db.houses.ToList();
			List<MHouse> Mhouses = new List<MHouse> {};
			foreach (House h in houses) {
				if( h.organization == id )
					Mhouses.Add (new MHouse (h));
			}
			return Json (Mhouses, JsonRequestBehavior.AllowGet);
		}
    }
}