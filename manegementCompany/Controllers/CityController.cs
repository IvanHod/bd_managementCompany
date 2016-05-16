using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.ContextDbs;
using web.Models;

namespace manegementCompany.Controllers
{
    public class CityController : Controller
	{
		private AddressContext db;

		public CityController()
		{
			db = new AddressContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

		[HttpPost]
		public JsonResult Create([Bind (Include = "name, street")]City city)
		{
			if (ModelState.IsValid) {
				db.Cities.Add (city);
				db.SaveChanges ();
				Region reg = db.Regions.Find (Request.Params["parent"]);
				reg.updateCity (city.id);
				db.SaveChanges ();
				return Json(city);
			}
			return null;
		}

		public JsonResult Select()
		{
			List<City> cities = db.Cities.ToList ();
			return Json (cities, JsonRequestBehavior.AllowGet);
		}
    }
}
