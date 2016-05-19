using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using web.ContextDbs;
using web.Models;

namespace manegementCompany.Controllers
{
	public class HomeController : Controller
	{
		private PeopleContext db;

		public HomeController()
		{
			db = new PeopleContext ();
		}

		public ActionResult Index ()
		{
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";

			List<Organization> organizations = this.db.Organizations.ToList ();

			return View (organizations);
		}

		public ActionResult logout()
		{
			Session ["Model"] = null;
			return RedirectToAction ("Index");
		}
	}
}

