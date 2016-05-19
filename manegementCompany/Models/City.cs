using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("city")]
	public class City
	{
		public City ()
		{
		}

		[Column("id")]
		public int id { get; set; }

		[Column("name")]
		public string name { get; set; }

		[Column("street")]
		public string street { get; set; }

		public void updateCity (int st) {
			if( street == null || street == "" )
				street = "" + st;
			else
				street += "," + st;
		}

	}
}

