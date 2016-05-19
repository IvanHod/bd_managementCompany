using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.ContextDbs;

namespace manegementCompany.Controllers
{
    public class OwnerController : Controller
	{
		private OwnerContext db;

		private HouseContext houseDb;

		public OwnerController()
		{
			db = new OwnerContext ();
			houseDb = new HouseContext ();
		}

        public ActionResult Index()
        {
			if (Session ["Model"] != null && !((AuthModel)Session ["Model"]).isOrganization ())
				return View ( db.owners.Find(((AuthModel)Session["Model"]).getId()));
			else
				return RedirectToAction ("Index", "Home");
        }

        public ActionResult Details(int id)
        {
			Owner ow = db.owners.Find(id);
			return View(ow);
        }

		public ActionResult Create(string id)
		{
			return View (new MOwner(Int32.Parse(id)));
		} 

        [HttpPost]
		public ActionResult Create(
			[Bind (Include = "name,lastName,patronimic,phone,email,password,room,services")]MOwner o)
        {
			try {
				//if (ModelState.IsValid) {
				o.organization = ((AuthModel)Session["Model"]).getId();
				Owner owner = new Owner(o);
				db.owners.Add(owner);
				db.SaveChanges();
				houseDb.rooms.Find(owner.room).owner = owner.id;
				houseDb.SaveChanges();
				return RedirectToAction ("Details/"+owner.room, "Room");
            } catch {
                return View ();
            }
        }
        
        public ActionResult Edit(int id)
        {
			Owner ow = db.owners.Find(id);
			return View(ow);
        }

        [HttpPost]
		public ActionResult Edit(int id, 
			[Bind(Include = "name,lastName,patronimic,phone,email,password,room,services")]MOwner o)
        {
			try {
				o.id = id;
				o.organization = ((AuthModel)Session["Model"]).getId();
				Owner owner = new Owner(o);
				db.owners.Find(id).editOw(owner);
				db.SaveChanges();
				return RedirectToAction("Details/"+owner.room,"Room");
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

		public ActionResult Authorization(AuthorizationModel auth)
		{
			try {
				if( ModelState.IsValid ) {
					Owner owner = (from own in db.owners where 
						own.email == auth.email && own.password == auth.password select own).First();
					if( owner != null ) {
						Session["Model"] = new AuthModel(owner);
						return RedirectToAction("Index");
					} else {
						ModelState.AddModelError("notPair", "Не существует введенной комбинации email и пароля");
						return View (auth);
					}
				}
				return View(auth);
			} catch {
				ModelState.AddModelError("notPair", "Не существует введенной комбинации email и пароля");
				return View (auth);
			}
		}
    }
}