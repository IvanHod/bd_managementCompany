using System;
using System.ComponentModel.DataAnnotations.Schema;
using web.ContextDbs;

namespace web.Models
{
	[Table("address")]
	public class Address
	{
		private PeopleContext db;

		public Address ()
		{
			db = new PeopleContext ();
		}

		public Address (string _region, string _area, string _city, string _street, string _house)
		{
			db = new PeopleContext ();
			region = _region;
			area = _area;
			city = _city;
			street = _street;
			house = _house;
		}

		[Column("id")]
		public int id { get; set; }

		[Column("region")]
		public string region { get; set; }

		[Column("area")]
		public string area { get; set; }

		[Column("city")]
		public string city { get; set; }

		[Column("street")]
		public string street { get; set; }

		[Column("house")]
		public string house { get; set; }

		public Address save() {
			db.Addresses.Add (this);
			db.SaveChanges ();
			return this;
		}
	}
}

