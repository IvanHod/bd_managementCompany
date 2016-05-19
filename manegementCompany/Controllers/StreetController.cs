using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.ContextDbs;
using web.Models;

namespace manegementCompany.Controllers
{
    public class StreetController : Controller
	{
		private AddressContext db;

		public StreetController()
		{
			db = new AddressContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

		public JsonResult Create([Bind (Include = "name, house")]Street street)
		{
			if (ModelState.IsValid) {
				db.Streets.Add (street);
				db.SaveChanges ();
				int parent = Int32.Parse (Request.Params["parent"]);
				City ct = db.Cities.Find (parent);
				ct.updateCity (street.id);
				db.SaveChanges ();
				return Json(street);
			}
			return null;
		}

		public JsonResult Select(int parent)
		{
			List<Street> streets = new List<Street> { };
			string stringStreets = db.Cities.Find (parent).street;
			if (stringStreets != null && stringStreets != "") {
				string[] streetsStrs = stringStreets.Split (',');
				foreach (string str in streetsStrs) {
					streets.Add(db.Streets.Find( Int16.Parse(str) ));	
				}
			}
			return Json (streets, JsonRequestBehavior.AllowGet);
		}
    }
}
