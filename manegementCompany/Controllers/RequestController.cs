using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.ContextDbs;
using web.Models;

namespace manegementCompany.Controllers
{
    public class RequestController : Controller
    {

		private PeopleContext db;

		private OwnerContext ownerDb;

		private ServiceContext serviceDb;

		public RequestController ()
		{
			db = new PeopleContext ();
			ownerDb = new OwnerContext ();
			serviceDb = new ServiceContext ();
		}

        public ActionResult Index()
        {
			if (Session ["Model"] != null) {
				string[] requestsId = db.Organizations.Find(((AuthModel)Session ["Model"]).getId())
					.requests.Split (',');
				List<MRequest> requests = new List<MRequest> { };
				foreach (string id in requestsId) {
					DBRequest model = db.Requests.Find (Int16.Parse (id));
					Owner owner = ownerDb.owners.Find (model.owner);
					string service = serviceDb.Services.Find (model.service).name;
					requests.Add (new MRequest (model, owner.lastName + " " + owner.name + " " + owner.patronimic, service));
				}
				return View (requests);
			} else
				return RedirectToAction ("Index", "Home");
        }
    }
}
