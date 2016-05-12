using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;

namespace manegementCompany.Controllers
{
    public class PersonController : Controller
    { 
		private PeopleContext db;

		public PersonController() 
		{
			db = new PeopleContext ();
		}

        public ActionResult Index()
		{
			List<Person> people = this.db.People.ToList ();
			return View (people);
        }

        public ActionResult Details(int? id)
        {
			if (id == null) {
				return RedirectToAction ("Index");
			}

			Person person = this.db.People.Find (id);
			if (person == null)
				return HttpNotFound ();
			return View (person);
        }

        public ActionResult Create()
        {
            return View ();
        } 

        [HttpPost]
		public ActionResult Create([Bind (Include = "firstName, secondName")]Person p)
        {
			if (ModelState.IsValid) {
				db.People.Add (p);
				db.SaveChanges ();
				return RedirectToAction ("Index");
			}
			return View ();
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
			Person person = db.People.Find (id);
			if (person != null) {
				db.People.Remove (person);
				db.SaveChanges ();
			}
			return RedirectToAction ("Index");
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