using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;

namespace manegementCompany.Controllers
{
    public class OrganizationController : Controller
	{
		private PeopleContext db;

		public OrganizationController()
		{
			db = new PeopleContext ();
		}

        public ActionResult Index()
        {
            return View ();
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
				Address legalAddress = new Address (
					Request.Params["address[region]"],
					"",
					Request.Params["address[city]"],
					Request.Params["address[street]"],
					Request.Params["address[house]"]
				).save();
				Address address = new Address (
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
    }
}