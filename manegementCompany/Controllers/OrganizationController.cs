using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;
using web.Session;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace manegementCompany.Controllers
{
    public class OrganizationController : Controller
	{
		private PeopleContext db;

		private OwnerContext ownerDb;

		private ServiceContext serviceDb;

		public OrganizationController()
		{
			db = new PeopleContext ();
			ownerDb = new OwnerContext ();
			serviceDb = new ServiceContext ();
		}

        public ActionResult Index()
        {
			AuthModel auth = (AuthModel)Session ["Model"];
			if ( auth != null && auth.isOrganization() ) {
				return View ( auth.organization );
			} else
				return RedirectToAction ("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            return View ();
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
		public ActionResult Create(
			[Bind (Include = "fullName, name, phone, email,password,INN,KPP,OGRN,OKTMO")]Organization o)
        {
            //try {
				Address address = new Address (
					Request.Params["address[region]"],
					"",
					Request.Params["address[city]"],
					Request.Params["address[street]"],
					Request.Params["address[house]"]
				).save();
				Address legalAddress = new Address (
					Request.Params["legalAddress[region]"],
					"",
					Request.Params["legalAddress[city]"],
					Request.Params["legalAddress[street]"],
					Request.Params["legalAddress[house]"]
				).save();
				o.legalAddress = legalAddress.id;
				o.address = address.id;
				db.Organizations.Add (o);
				db.SaveChanges ();
                return RedirectToAction ("Index");
            /*} catch {
                return View ();
            }*/
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

		[HttpPost]
		public bool Generation()
		{
			try {
				List<Owner> owners = ownerDb.owners.ToList ();
				foreach (Owner own in owners) {
					own.servicesPay = own.services;
				}
				ownerDb.SaveChanges ();
				return true;
			} catch {
				return false;
			}
		}

		[HttpPost]
		public bool Service(DBRequest request) {
			try {
				int idOrganization = request.organization;
				db.Requests.Add(request);
				db.SaveChanges();
				db.Organizations.Find(idOrganization).addRequest(request.id);
				db.SaveChanges();
				ownerDb.owners.Find(request.owner).removePayService(request.service);
				ownerDb.SaveChanges();
				return true;
			} catch {
				return false;
			}
		}

		[HttpPost]
		public bool ServiceComplet(int request, string price) {
			try {
				int idOrganization = ((AuthModel)Session["Model"]).getId();
				db.Requests.Remove(db.Requests.Find(request));
				db.SaveChanges();
				db.Organizations.Find(idOrganization).removeRequest(request);
				db.SaveChanges();
				return true;
			} catch {
				return false;
			}
		}

		[HttpPost]
		public ActionResult Authorization(AuthorizationModel auth)
		{
			try {
				if( ModelState.IsValid ) {
					Organization org = db.authorization(auth.email, auth.password);
					if( org != null ) {
						Session["Model"] = new AuthModel(org);
						return RedirectToAction("Index");
					} else {
						ModelState.AddModelError("notPair", "Не существует введенной комбинации email и пароля");
						return View (auth);
					}
				}
				return View(auth);
			} catch {
				return View ();
			}
		}
    }
}