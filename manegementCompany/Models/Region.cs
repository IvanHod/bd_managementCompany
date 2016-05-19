using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace web.Models
{
	[Table("region")]
	public class Region
	{
		public Region ()
		{
		}

		[Column("id")]
		public int id { get; set; }

		[Column("name")]
		public string name { get; set; }

		[Column("city")]
		public string city { get; set; }

		public void updateCity (int c) {
			if( city == null || city == "" )
				city = "" + c;
			else
				city += "," + c;
		}
	}
}

