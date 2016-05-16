using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.ContextDbs;
using web.Models;

namespace manegementCompany.Controllers
{
    public class RegionController : Controller
	{
		private AddressContext db;

		public RegionController()
		{
			db = new AddressContext ();
		}

        public ActionResult Index()
        {
            return View ();
        }

		[HttpPost]
		public JsonResult Create([Bind (Include = "name, city")]Region r)
		{
			if (ModelState.IsValid) {
				db.Regions.Add (r);
				db.SaveChanges ();
				return Json(r);
			}
			return null;
		}

		public JsonResult Select()
		{
			List<Region> regions = db.Regions.ToList ();
			return Json (regions, JsonRequestBehavior.AllowGet);
		}
    }
}
