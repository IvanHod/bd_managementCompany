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
				int parent = Int32.Parse (Request.Params["parent"]);
				Region reg = db.Regions.Find (parent);
				reg.updateCity (city.id);
				db.SaveChanges ();
				return Json(city);
			}
			return null;
		}

		public JsonResult Select(int parent)
		{
			List<City> cities = new List<City> { };
			string stringCities = db.Regions.Find (parent).city;
			if (stringCities != null && stringCities != "") {
				string[] citiesStrs = stringCities.Split (',');
				foreach (string sity in citiesStrs) {
					cities.Add(db.Cities.Find( Int16.Parse(sity) ));	
				}
			}
			return Json (cities, JsonRequestBehavior.AllowGet);
		}
    }
}
